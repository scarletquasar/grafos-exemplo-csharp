using GrafosExemplo;
using System.Text.Json;

List<Node> nodes = new List<Node>(); // Lista de Vertices de nossos verices


// Criação do nosso Vertice base e adição dele na nossa lista de nodos
Node baseNode = new Node("You", new List<string> { "Coding", "Playing videogames", "Watching birds", "Drinking water" }, true);
nodes.Add(baseNode);

//Criação de nossos nodods "friends" através de uma lista
string[] friendNames = { "Friend 1", "Friend 2", "Friend 3", "Friend 4" };
string[][] friendHobbies = {
    new string[] { "Driving cars", "Watching birds", "Drinking water" },
    new string[] { "Riding dinosaurs", "Petting dogs", "Drinking monster" },
    new string[] { "Driving cars", "Drinking water" },
    new string[] { "Watching birds" }
};

// Iteração e criação de novos nodos
for (int i = 0; i < friendNames.Length; i++)
{
    Node friend = new Node(friendNames[i], new List<string>(friendHobbies[i]), false);
    nodes.Add(friend);
}

// Montaremos o esqueleto dos grafos definindo as conexões por
// referência com o método que criamos mais cedo, na definição
// da classe "Node".

baseNode.AddConnection(nodes[1]);
baseNode.AddConnection(nodes[2]);
nodes[1].AddConnection(nodes[3]);
nodes[2].AddConnection(nodes[4]);


// Para servir de resultado da nossa pesquisa de grafo, criamos
// a lista "result" que conterá os vértices encontrados no grafo
// que contenham pelo menos um hobby, na categoria "Hobbies" que
// seja igual ao objeto de base.
var result = new List<Node>();

// Nosso método une recursividade à iteração de loops para pesquisar
// por vértices em um grafo onde o objeto base é o "baseNode", ele será
// pesquisado e todos os resultados ficarão dentro da variável "result".
void SearchWithHobbiesIntersection(Node baseNode, Node node)
{
    // Para cada conexão do vértice que está sendo analisad
    // no momento, ele verificará se o mesmo tem algum hobby
    // igual ao objeto base passado, caso sim, a lista "result"
    // terá esse objeto adicionado.
    foreach(var connection in node.Connections!)
    {
        var matchAnyHobby = connection
            .Hobbies!
            .Where(hobby => baseNode!.Hobbies!.Contains(hobby))
            .Any();

        if (matchAnyHobby)
        {
            result!.Add(connection);
        }

        // O algoritmo fará o mesmo com todas as sub-conexões,
        // usando recursividade.
        SearchWithHobbiesIntersection(baseNode, connection);
    }
}

// Nosso resultado esperado é uma lista contendo os seguintes textos: friend1, friend3, friend4.
SearchWithHobbiesIntersection(baseNode, baseNode);

// Escreveremos apenas os identificadores da nossa lista de resultados
// para visualizar melhor se está tudo certo.
Console.WriteLine(JsonSerializer.Serialize(result.Select(node => node.Identifier)));