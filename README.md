Projeto ETL - Programação Funcional (Insper 2025.1)

Este projeto implementa um pipeline de Extract, Transform, Load (ETL) em F# para processar dados de gestão de pedidos. O objetivo é extrair dados brutos de pedidos e itens, transformá-los através de regras de negócio funcionais e gerar um relatório agregado.

Estrutura da Solução

Seguindo as boas práticas de organização de código em F#, o projeto foi dividido em dois componentes principais dentro de uma Solution .NET:

    ETL.Logic (Módulo Greet): Biblioteca contendo as funções puras, definições de tipos (Records) e a lógica de transformação.

    ETL.App (Módulo Main): Aplicativo de console responsável pelas funções impuras, como leitura de arquivos CSV, escrita de resultados e orquestração do fluxo.

Etapas do Pipeline

1. Extração (Extract)

Os dados são carregados a partir de arquivos CSV (order.csv e order_item.csv) para estruturas de Records. Foram utilizadas Helper Functions específicas para realizar o parse de cada linha, garantindo a tipagem correta desde o início.

2. Transformação (Transform)

A etapa de transformação é o coração funcional do projeto, utilizando conceitos avançados da linguagem:

    Inner Join: Realizado manualmente em F# para combinar as informações de pedidos e seus respectivos itens.

    Filter: Aplicação de filtros parametrizados para selecionar apenas pedidos com status: Complete e origin: O (Online).

    Map & GroupBy: Utilizados para calcular a receita (quantidade × preço) e os impostos de cada item.

    Fold: Agregação dos valores para gerar o somatório final por pedido.

3. Carga (Load)

O resultado final é exportado para um arquivo output.csv, contendo o identificador do pedido, o montante total e o somatório de impostos pagos. 

    Características Funcionais Aplicadas:

    Imutabilidade: Todas as transformações geram novos dados sem alterar as fontes originais, facilitando o raciocínio e evitando bugs de estado.

    Funções de Ordem Superior (HOF): Uso intensivo de List.map, List.filter e List.fold para processamento modular.

    Pattern Matching: Utilizado para desestruturar listas e tratar casos específicos de forma segura.

    Pipelines (|> ): O código utiliza o operador de pipeline para criar um fluxo de dados legível e elegante.

Declaração de Uso de IA

Este projeto foi desenvolvido com o auxílio do assistente Gemini. A IA foi utilizada para:

    Estruturação da arquitetura de Solution multi-projeto no .NET.

    Depuração de erros de configuração nos arquivos .fsproj.

    Refinamento da lógica de Inner Join manual e agregação por Map.

Como Executar:

Na pasta raiz do projeto, execute:

    dotnet run --project Main
    
O resultado será gerado no arquivo output.csv.