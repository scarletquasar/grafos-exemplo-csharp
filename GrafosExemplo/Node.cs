namespace GrafosExemplo
{
    // Definição do vértice de nosso grafo, cada "Node" significa
    // a presença de um item dentro de um grafo.
    public class Node
    {
        public string? Identifier { get; set; }
        public List<Node>? Connections { get; set; }
        public List<string>? Hobbies { get; set; }
        public bool? IsBase { get; set; } 

        public Node(string? identifier, List<string>? hobbies, bool isBase)
        {
            Identifier = identifier;
            Connections = new();
            Hobbies = hobbies;
            IsBase = isBase;
        }

        // O método "AddConnection" adiciona um novo vértice, que também é
        // um node, por referência, para esse Node pai especificado.
        public void AddConnection(Node connection)
        {
            Connections?.Add(connection);
        }
    }
}
