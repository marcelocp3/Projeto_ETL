open ETL.Logic

[<EntryPoint>]
let main _ =
    printfn "--- Iniciando Processo ETL ---"
    
    // Extração usando o módulo IO
    let orders = IO.loadOrders "order.csv"
    let items = IO.loadItems "order_item.csv"
    
    // Transformação usando o módulo Transform (do namespace ETL.Logic)
    let resultado = 
        Transform.joinData orders items
        |> Transform.processFinal "CNicomplete" "O"
        
    // Carga usando o módulo IO
    IO.saveCsv "output.csv" resultado
    
    printfn "Projeto concluído com sucesso! Verifique o arquivo output.csv"
    0