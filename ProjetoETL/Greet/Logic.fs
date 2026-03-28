namespace ETL.Logic

type Order = { Id: int; Status: string; Origin: string }
type OrderItem = { OrderId: int; Quantity: int; Price: float; Tax: float }
type Joined = { Id: int; Total: float; TaxValue: float; Status: string; Origin: string }

module Transform =
    /// Realiza o Inner Join entre tabelas (Transformação) [cite: 871, 872]
    let joinData (orders: Order list) (items: OrderItem list) =
        items |> List.choose (fun i ->
            orders |> List.tryFind (fun o -> o.Id = i.OrderId)
            |> Option.map (fun o -> 
                { Id = o.Id; Total = float i.Quantity * i.Price; 
                  TaxValue = (float i.Quantity * i.Price) * (i.Tax / 100.0);
                  Status = o.Status; Origin = o.Origin }))

    /// Filtra e agrega os dados usando map e groupBy [cite: 859]
    let processFinal status origin data =
        data 
        |> List.filter (fun r -> r.Status = status && r.Origin = origin)
        |> List.groupBy (fun r -> r.Id)
        |> List.map (fun (id, group) ->
            (id, group |> List.sumBy (fun x -> x.Total), group |> List.sumBy (fun x -> x.TaxValue)))