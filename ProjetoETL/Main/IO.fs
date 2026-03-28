module IO

open System.IO
open ETL.Logic

let loadOrders path =
    File.ReadAllLines(path) 
    |> Array.skip 1 // Pula o cabeçalho
    |> Array.map (fun l -> 
        let c = l.Split(',') 
        { Id = int c.[0]; Status = c.[3]; Origin = c.[4] })
    |> Array.toList

let loadItems path =
    File.ReadAllLines(path) 
    |> Array.skip 1 
    |> Array.map (fun l -> 
        let c = l.Split(',') 
        { OrderId = int c.[0]; Quantity = int c.[2]; Price = float c.[3]; Tax = float c.[4] })
    |> Array.toList

let saveCsv path (data: (int * float * float) list) =
    let header = "order_id,total_amount,total_taxes"
    let lines = data |> List.map (fun (id, tot, tax) -> sprintf "%d,%.2f,%.2f" id tot tax)
    File.WriteAllLines(path, header :: lines)