using GrafosExemplo;
using System.Text.Json;

// Definição de nosso vértice base, de onde começaremos
// a fazer nossa pesquisa de conteúdo de grafo.
var baseNode = new Node("You", new List<string>
{
    "Coding",
    "Playing videogames",
    "Watching birds",
    "Drinking water"
});

// Definição das conexões e sub-conexões que nosso vértice
// base terá, com itens na categoria "Hobbies" semelhantes
// para oferecer uma pesquisa com resultados válidos.
var friend1 = new Node("Friend 1", new List<string>()
{
    "Driving cars",
    "Watching birds",
    "Drinking water"
});

var friend2 = new Node("Friend 2", new List<string>()
{
    "Riding dinosaus",
    "Petting dogs",
    "Drinking monster"
});

var friend3 = new Node("Friend 3", new List<string>()
{
    "Driving cars",
    "Drinking water"
});

var friend4 = new Node("Friend 4", new List<string>()
{
    "Watching birds"
});

// Montaremos o esqueleto dos grafos definindo as conexões por
// referência com o método que criamos mais cedo, na definição
// da classe "Node".
baseNode.AddConnection(friend1);
baseNode.AddConnection(friend2);
friend1.AddConnection(friend3);
friend2.AddConnection(friend4);

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