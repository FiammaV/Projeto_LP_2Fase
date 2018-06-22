<!--
Projeto de 2ª época de Linguagens de Programação I 2017/2018 (c) by Nuno Fachada

Projeto de 2ª época de Linguagens de Programação I 2017/2018 is licensed under a
Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

You should have received a copy of the license along with this
work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.
-->

[![Enunciado: CC BY-NC-SA 4.0](https://img.shields.io/badge/Enunciado-CC%20BY--NC--SA%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-sa/4.0/)
[![Código: MIT](https://img.shields.io/badge/Código-MIT-blue.svg)](http://opensource.org/licenses/MIT)

# Projeto de 2ª época de Linguagens de Programação I 2017/2018

## Descrição do problema

Pretende-se que os alunos desenvolvam, em grupos de 1 a 3 elementos, um
jogo/simulador em C# no qual zombies perseguem e infetam humanos. O jogo
desenrola-se numa grelha 2D limitada nos lados (não
toroidal<sup>[1](#fn1)</sup>) com dimensões _X_ e _Y_ e vizinhança de Von
Neumann<sup>[2](#fn2)</sup>. Em cada célula da grelha pode estar no máximo um
agente, que pode ser um **zombie** ou um **humano**. No início da simulação
existem _n<sub>z</sub>_ zombies e _n<sub>h</sub>_ humanos, num total de _n =
n<sub>z</sub>_ + _n<sub>h</sub>_ agentes. Os agentes devem ser espalhados
aleatoriamente pela grelha no início de cada jogo.

O jogo é _turn-based_, e em cada _turn_ (iteração) cada agente pode realizar
uma ação. Os humanos podem apenas realizar um tipo de ação: movimento. Os
zombies podem realizar dois diferentes tipos de ação: 1) movimento; e, 2)
infeção de humanos. O movimento dos agentes pode ser realizado para uma célula
vazia numa vizinhança de Von Neumman de raio 1. A infeção de humanos pode ser
realizada por zombies quando o humano está numa célula adjacente na vizinhança
de Von Neumman. A ordem em que os agentes executam as suas ações em cada _turn_
é aleatória<sup>[3](#fn3)</sup>, de modo a que nenhum agente em específico
obtenha a vantagem de agir cedo durante todo o jogo.

Os agentes podem ser controlados pelo computador através de uma Inteligência
Artificial (IA) básica, ou podem ser controlados por jogadores. Neste último
caso, um jogador que controle determinado agente pode decidir o destino do
mesmo. Se o agente for um zombie, a ação de infeção equivale à indicação de
movimento para o local onde está um humano. Nesse caso o zombie não se move
(pois o local já está ocupado pelo humano), mas o humano é convertido em
zombie. Se o humano era controlado por um jogador, deixa de o ser, e passa a
ser controlado pela IA. O jogo termina quando não existirem mais agentes do
tipo humano na grelha.

Caso um agente seja controlado pela IA, as suas decisões dependem do tipo de
agente:

* Humano - Tenta mover-se na direção oposta ao zombie mais próximo. Se a célula
  para onde o humano deseja mover-se estiver ocupada, o humano fica no mesmo
  local.
* Zombie - Caso exista um humano numa célula adjacente, infeta-o. Caso
  contrário, tenta mover-se na direção do humano mais próximo. Se a célula para
  onde o zombie deseja mover-se estiver ocupada, o zombie fica no mesmo local.

O jogo termina quando o número máximo de _turns_ for atingido, ou quando não
existirem mais humanos na simulação.

## Modo de funcionamento

### Invocação do programa

O programa deve aceitar sete opções na linha de comando<sup>[4](#fn4)</sup>:

* `-x` - Dimensão horizontal da grelha de jogo.
* `-y` - Dimensão vertical da grelha de jogo.
* `-z` - Número total de zombies.
* `-h` - Número total de humanos.
* `-Z` - Número de zombies controlados por jogadores.
* `-H` - Número de humanos controlados por jogadores.
* `-t` - Número máximo de _turns_.

Um exemplo de execução:

```
Program.exe -x 20 -y 20 -z 10 -h 30 -Z 1 -H 2 -t 1000
```

As opções de linha de comandos podem também ser definidas diretamente no Visual
Studio 2017 da seguinte forma: 1) clicar com o botão direito em cima do nome do
projeto; 2) selecionar "Properties"; 3) selecionar separador "Debug"; e, 4) na
caixa "Command line arguments" especificar os argumentos desejados.

As opções indicadas são obrigatórias e podem ser dadas em qualquer ordem, desde
que o valor numérico suceda à opção propriamente dita. Se alguma das opções for
omitida o programa deve terminar com uma mensagem de erro indicando o modo de
uso.

### Modos de jogo

#### Modo automático

O programa entra em modo automático quando não existem agentes controlados
por jogadores. Neste modo o jogo desenrola-se sem intervenção direta do
utilizador. A visualização deve ser atualizada no fim de cada _turn_ (pelo
menos). No entanto, de modo a ser possível observar a evolução da simulação,
poderá ser boa ideia solicitar ao utilizador para pressionar uma tecla antes de
se dar início à próxima _turn_.

#### Modo interativo

Este modo é semelhante ao automático, apenas com duas pequenas diferenças: 1)
cada vez que um agente controlado pelo jogador é chamado a agir, o programa
fica a aguardar o _input_ do jogador sobre que ação tomar; e, 2) a visualização
do jogo deve ser atualizada imediatamente antes de ser solicitado _input_ a um
jogador (pelo menos). Se a dada altura deixarem de existir agentes controlados
pelo jogador, o programa entra em modo automático.

<a name="visualize"></a>

## Visualização do jogo

A visualização do jogo deve ser feita em modo de texto (consola), fazendo uso
de cores e de carateres [Unicode][], ambos suportados nativamente no C#, para
facilitar a clareza da ação no jogo. Para o efeito deve ser incluída a
instrução `Console.OutputEncoding = Encoding.UTF8;` no método `Main()` (é
necessário usar o _namespace_ `System.Text`).

No mínimo, a visualização deve distinguir claramente entre humanos e zombies,
bem como entre agentes controlados pela IA (NPCs) e agentes controlados pelo
jogador. Cada agente deve ainda ter um ID específico, em hexadecimal, de modo
a que o jogador possa saber que agente(s) controla, além de que pode faciliar
bastante o _debug_ do jogo.

A [Figura 1](#fig1) mostra uma possível implementação mínima da visualização do
jogo para uma grelha 8x8.

<a name="fig1"></a>

```
.   .   .   .   .   .   .   .         N
                                      |
.   .   .   .  z01 h03  .   .      O--+--L
                                      |
.   .   .   .  H00  .   .   .         S

.   .   .   .  h02  .   .   .

.   .   .   .   .   .   .   .

.  z00  .   .   .   .   .   .

.   .   .   .   .   .  h01  .

.   .   .   .   .   .   .   .


* Proximo a jogar: H00
  - A Norte existe o zombie 01 (IA).
  - A Sul existe o humano 02 (IA).
  - A Oeste o caminho está livre.
  - A Leste o caminho está livre.
* Qual o caminho a seguir? A (oeste) ou D (leste) >
```

**Figura 1** - Possível implementação mínima da visualização do jogo para uma
grelha 8x8. Os zombies estão associados à letra `z`, enquanto os humanos são
representados pela letra `h`. Agentes com letra maiúscula são controlados pelo
jogador.

## Implementação

<a name="orgclasses"></a>

### Organização do projeto e estrutura de classes

O projeto deve estar devidamente organizado, fazendo uso de classes, _structs_
e enumerações. Cada classe, _struct_ ou enumeração deve ser colocada num
ficheiro com o mesmo nome. Por exemplo, uma classe chamada `Agent` deve ser
colocada no ficheiro `Agent.cs`. A estrutura de classes deve ser bem pensada e
organizada de uma forma lógica, e [cada classe deve ter uma responsabilidade
específica e bem definida][SRP].

<a name="fases"></a>

### Fases da implementação

O jogo deve ser implementado incrementalmente em várias fases. Os projetos
precisam de implementar pelo menos a Fase 1 para serem avaliados.

#### Fase 1

Na fase 1 deve ser implementado tudo o que é pedido no enunciado, aceitando-se
as seguintes simplificações:

* Os agentes controlados pela IA podem mover-se de forma aleatória, respeitando
no entanto as regras do jogo, como por exemplo: a) só pode existir um agente
por célula da grelha; ou, b) se um zombie tentar mover-se para o local onde
está um humano, esse humano é infetado (mas ambos os agentes mantém-se no local
onde estavam).
* Implementação apenas da visualização mínima, como exemplificado na
[Figura 1](#fig1).

A implementação completa desta fase equivale a 50% de cumprimento do
[objetivo **O1**](#objetivos) (nota máxima 5). Atenção que a nota mínima do
projeto é 4.5, pelo que os restantes [objetivos](#objetivos) têm de ser
totalmente cumpridos para o grupo obter aprovação apenas com a fase 1.

#### Fase 2

Na fase 2 deve ser implementada uma visualização que faça uso de cores e
caracteres [Unicode][] para fácil distinção entre os diferentes agentes.

Aceita-se ainda a simplificação da IA descrita na fase 1.

A implementação completa desta fase equivale a 60% de cumprimento do
[objetivo **O1**](#objetivos) (nota máxima 6).

#### Fase 3

Na fase 3 não se aceitam simplificações, pelo que o projeto deverá ser
desenvolvido tal como descrito no enunciado. Em concreto, a IA dos agentes deve
ser totalmente implementada como solicitado.

A implementação completa desta fase equivale a 100% de cumprimento do
[objetivo **O1**](#objetivos) (nota máxima 10).

#### Fase extra

Na fase extra, além de tudo o que é pedido para a fase 3, deve também ser
desenvolvido um sistema de _save games_. Deve ser possível guardar a situação
do jogo no fim de cada _turn_. O _load_ de um _save game_ deve ser feito na
invocação do programa, através de uma opção adicional na linha de comandos:

* `-s` - Indica ficheiro de _save game_ a fazer _load_, por exemplo:
`Program.exe -s mysave.sav`

Esta opção sobrepõem-se a todas as outras.

A implementação completa desta fase permite compensar eventuais problemas
noutras partes do código e/ou do projeto, facilitando a obtenção da nota
máxima de 10 valores.

<a name="objetivos"></a>

## Objetivos e critério de avaliação

Este projeto tem os seguintes objetivos:

* **O1** - Jogo deve funcionar como especificado (ver [fases](#fases) de
  implementação, obrigatório implementar pelo menos a Fase 1).
* **O2** - Projeto e código bem organizados, nomeadamente: a) estrutura de
  classes bem pensada (ver secção [Organização do projeto e estrutura de
  classes](#orgclasses)); b) código devidamente comentado e indentado; c)
  inexistência de código "morto", que não faz nada, como por exemplo
  variáveis ou métodos nunca usados; d) soluções [simples][KISS] e eficientes;
  e, e) projeto compila e executa sem erros e/ou  _warnings_.
* **O3** - Projeto adequadamente comentado e documentado. Documentação deve ser
  feita com comentários de documentação XML, e a documentação (gerada com
  [Doxygen][], [Sandcastle][] ou ferramenta similar) deve estar incluída no ZIP
  do projeto (mas não integrada no repositório Git).
* **O4** - Repositório Git deve refletir boa utilização do mesmo, com _commits_
  de todos os elementos do grupo e mensagens de _commit_ que sigam as melhores
  práticas para o efeito (como indicado
  [aqui](https://chris.beams.io/posts/git-commit/),
  [aqui](https://gist.github.com/robertpainsi/b632364184e70900af4ab688decf6f53),
  [aqui](https://github.com/erlang/otp/wiki/writing-good-commit-messages) e
  [aqui](https://stackoverflow.com/questions/2290016/git-commit-messages-50-72-formatting)).
* **O5** - Relatório em formato [Markdown][] (ficheiro `README.md`), organizado
  da seguinte forma:
  * Título do projeto.
  * Nome dos autores (primeiro e último) e respetivos números de aluno.
  * Indicação do repositório público Git utilizado. Esta indicação é opcional,
    pois podem preferir desenvolver o projeto num repositório privado.
  * Informação de quem fez o quê no projeto. Esta informação é **obrigatória**
    e deve refletir os _commits_ feitos no Git.
  * Descrição da solução:
    * Fase implementada (1 a 3, ou extra).
    * Arquitetura da solução, com breve explicação de como o programa foi
      organizado e indicação das estruturas de dados usadas (para a grelha de
      jogo, por exemplo), bem como os algoritmos implementados (para procura de
      inimigo mais próximo, por exemplo).
    * Um diagrama UML mostrando as relações entre as classes e tipos
      desenvolvidos no jogo. Não é necessário indicar os conteúdos das classes
      (variáveis, propriedades, métodos, etc).
    * Um fluxograma mostrando o _game loop_.
  * Conclusões e matéria aprendida.
  * Referências:
    * Incluindo trocas de ideias com colegas, código aberto reutilizado e
      bibliotecas de terceiros utilizadas. Devem ser o mais detalhados
      possível.
  * **Nota:** o relatório deve ser simples e breve, com informação mínima e
    suficiente para que seja possível ter uma boa ideia do que foi feito.
    Atenção aos erros ortográficos, pois serão tidos em conta na nota final.

O projeto tem um peso de 10 valores na nota final da disciplina e será avaliado
de forma qualitativa. Isto significa que todos os objetivos têm de ser
parcialmente ou totalmente cumpridos. Ou seja, se os alunos ignorarem
completamente um dos objetivos, a nota final será zero.

A nota individual de cada aluno será atribuída com base na avaliação do
projeto, na percentagem de trabalho realizada (indicada no relatório e
verificada através dos _commits_) e na discussão do projeto. Se o aluno tiver
realizado uma percentagem equitativa do projeto e se souber explicar o que fez
durante a discussão, então a nota individual deverá ser muito semelhante à
avaliação do projeto.

A nota mínima neste projeto para aprovação na componente prática de LP1 é de
4.5 valores.

## Entrega

O projeto deve ser entregue via Moodle até às 23h de 1 de julho de 2018.
Deve ser submetido um ficheiro `zip` com os seguintes conteúdos:

* Solução completa do projeto, contendo adicionalmente e obrigatoriamente:
  * Pasta escondida `.git` com o repositório Git local do projeto.
  * Documentação gerada com [Doxygen][], [Sandcastle][] ou ferramenta similar.
  * Ficheiro `README.md` contendo o relatório do projeto em formato [Markdown].
  * Ficheiros de imagem contendo o fluxograma e o diagrama UML de classes.

Notas adicionais para entrega:

* Os grupos podem ter entre 1 a 3 alunos.
* A solução deve ser entregue na forma de uma solução C# para Visual Studio
  2017.
* O projeto deve ser do tipo Console App (.NET Framework ou .NET Core).
* Todos os ficheiros do projeto devem ser gravados em codificação [UTF-8][].
  Este pormenor é especialmente importante em Windows pois regra geral a
  codificação [UTF-8][] não é usada por omissão. Em todo o caso, e dependendo
  do editor usado, a codificação [UTF-8][] pode ser selecionada na janela de
  "Save as" / "Guardar como", ou então nas preferências do editor utilizado.

## Honestidade académica

Nesta disciplina, espera-se que cada aluno siga os mais altos padrões de
honestidade académica. Isto significa que cada ideia que não seja do aluno deve
ser claramente indicada, com devida referência ao respetivo autor. O não
cumprimento desta regra constitui plágio.

O plágio inclui a utilização de ideias, código ou conjuntos de soluções de
outros alunos ou indivíduos, ou quaisquer outras fontes para além dos textos de
apoio à disciplina, sem dar o respetivo crédito a essas fontes. Os alunos são
encorajados a discutir os problemas com outros alunos e devem mencionar essa
discussão quando submetem os projetos. Essa menção **não** influenciará a nota.
Os alunos não deverão, no entanto, copiar códigos, documentação e relatórios de
outros alunos, ou dar os seus próprios códigos, documentação e relatórios a
outros em qualquer circunstância. De facto, não devem sequer deixar códigos,
documentação e relatórios em computadores de uso partilhado.

Nesta disciplina, a desonestidade académica é considerada fraude, com todas as
consequências legais que daí advêm. Qualquer fraude terá como consequência
imediata a anulação dos projetos de todos os alunos envolvidos (incluindo os
que possibilitaram a ocorrência). Qualquer suspeita de desonestidade académica
será relatada aos órgãos superiores da escola para possível instauração de um
processo disciplinar. Este poderá resultar em reprovação à disciplina,
reprovação de ano ou mesmo suspensão temporária ou definitiva da ULHT.

_Texto adaptado da disciplina de [Algoritmos e
Estruturas de Dados][aed] do [Instituto Superior Técnico][ist]_

## Notas

<sup><a name="fn1">1</a></sup> Num mapa toroidal 2D, a grelha "dá a volta" na
vertical e na horizontal. Neste caso o mapa não é toroidal, sendo limitado
pelos lados, pelo que os agentes não podem "dar a volta" nesse sentido.

<sup><a name="fn2">2</a></sup> Numa grelha 2D, a vizinhança de
[Von Neumann][] é composta pela célula central, pelas células do lado direito e
esquerdo e pelas células em cima e em baixo.

<sup><a name="fn3">3</a></sup> Por outras palavras, a lista de agentes deve ser
embaralhada (_shuffled_) no início de cada _turn_. O algoritmo de
[Fisher–Yates](https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle)
é um método de embaralhamento (_shuffling_) tipicamente utilizado para este
fim.

<sup><a name="fn4">4</a></sup> Os argumentos da linha de comandos estão
disponíveis num _array_ de _strings_ chamado `args` no método `Main()`, como
explicado nas páginas 285 e 286 do livro da disciplina.

## Referências

* <a name="ref1">\[1\]</a> Whitaker, R. B. (2016). The C# Player's Guide
  (3rd Edition). Starbound Software.

## Licenças

Este enunciado é disponibilizados através da licença [CC BY-NC-SA 4.0]. O
código associado é disponibilizado através da licença
[MIT](http://opensource.org/licenses/MIT).

## Metadados

* Autor: [Nuno Fachada]
* Curso:  [Licenciatura em Videojogos][lamv]
* Instituição: [Universidade Lusófona de Humanidades e Tecnologias][ULHT]

[GPLv3]:https://www.gnu.org/licenses/gpl-3.0.en.html
[CC BY-NC-SA 4.0]:https://creativecommons.org/licenses/by-nc-sa/4.0/
[lamv]:https://www.ulusofona.pt/licenciatura/videojogos
[Nuno Fachada]:https://github.com/fakenmc
[ULHT]:https://www.ulusofona.pt/
[aed]:https://fenix.tecnico.ulisboa.pt/disciplinas/AED-2/2009-2010/2-semestre/honestidade-academica
[ist]:https://tecnico.ulisboa.pt/pt/
[Markdown]:https://guides.github.com/features/mastering-markdown/
[Doxygen]:https://www.stack.nl/~dimitri/doxygen/
[Sandcastle]:https://github.com/EWSoftware/SHFB
[SRP]:https://en.wikipedia.org/wiki/Single_responsibility_principle
[KISS]:https://en.wikipedia.org/wiki/KISS_principle
[GP]:https://en.wikipedia.org/wiki/Procedural_generation
[Von Neumann]:https://en.wikipedia.org/wiki/Von_Neumann_neighborhood
[UTF-8]:https://en.wikipedia.org/wiki/UTF-8
[Unicode]:https://en.wikipedia.org/wiki/Unicode
[Random]:https://docs.microsoft.com/pt-pt/dotnet/api/system.random
[NextDouble()]:https://docs.microsoft.com/pt-pt/dotnet/api/system.random.nextdouble
[Next()]:https://docs.microsoft.com/pt-pt/dotnet/api/system.random.next
[função logística]:https://en.wikipedia.org/wiki/Logistic_function
[função linear por troços]:https://en.wikipedia.org/wiki/Piecewise_linear_function
[função logarítmica]:https://en.wikipedia.org/wiki/Logarithm#Logarithmic_function
[função linear]:https://en.wikipedia.org/wiki/Linear_function_(calculus)
[funções]:https://www.desmos.com/calculator/x5nmemnwsu
