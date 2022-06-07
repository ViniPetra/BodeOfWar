# BodeOfWar
![image](https://user-images.githubusercontent.com/89108219/168502761-1b18a409-87c0-4cbe-8107-7ff528f41dec.png)

## Resumo
Este é um projeto de um **Sistema Autônomo** que joga uma partida inteira de um jogo **Online**  contra até 3 adversários.

Neste projeto, o jogo de cartas *Bode Of War* foi recriado em *C#* usando *.NET  Framewok* e *Windows Forms* como parte do terceiro semestre do curso de Ciências da Computação do SENAC de São Paulo.

Além do servidor que o jogo se conecta e as funções que usamos da DLL, o projeto foi feito 100% à mão.

## Imagens do jogo
![image](https://user-images.githubusercontent.com/89108219/168503100-54c0de2e-46bf-44d2-be3f-49890181fff2.png)
![image](https://user-images.githubusercontent.com/89108219/168503130-5aaa1a38-68bf-43f2-b7e0-ac2af3415a5d.png)
![image](https://user-images.githubusercontent.com/89108219/168503157-8547b517-6b3e-4312-9de0-e717de318649.png)
![image](https://user-images.githubusercontent.com/89108219/168503179-3dafa30c-2033-4ba1-a82a-6d5e4181285d.png)
![image](https://user-images.githubusercontent.com/89108219/170893814-f1188d71-31ef-4fb2-b992-f6d65a1a2193.png)

Agradecimento especial ao @Yuri-barbosa21, que foi quem fez todas as imagens do projeto

## Visão do projeto
O projeto foi pensado para funcionar de forma extremamente dinâmica de forma que houvesse uma tela para cada menu necessário. Há o menu que lista as partidas e o que te pede credenciais para ingressar em alguma, por exemplo.

O rascunho **inicial** da dinâmica dos menus pode ser acessado [Aqui](https://xd.adobe.com/view/b89a2cd3-3c15-49ca-8827-7cf1908e99dc-edc9/)

Também é possível acessar os modos **Manual** e **Aleatório** do jogo que foram usados como protótipos e foi considerado importante manter no programa para analisar quão longe o projeto foi desenvolvido. 

## Detalhes técnicos
Foram usados conceitos de **Orientação a Objetos** na criação de classes como *Cartas, Jogador* e *Partida* (por exemplo) e seus respectivos atributos e métodos.

Apesar disso, o código não está 100% em conformidade com OOP pois há uma grande dificuldade em uma classe acessar controles da outra. Por exemplo: uma função em *Partida* não consegue mudar o texto de uma *label* de um *form*.

Também foi feito um trabalho intensivo na UX e UI do projeto. Foi usado, inclusive, um sistema de threading (BackGround Worker) para separar a GUI do processamento das funções para evitar congelamentos de tela.

**Todas as funções estão comentadas dentro do código** e podem ser acessadas neste repositório, caso tenha curiosidade.

A **estratégia** adotada para o sistema autônomo segue a seguinte lógica:

![image](https://user-images.githubusercontent.com/89108219/170899125-b2e8defd-1a8f-489b-bab2-69dc92557c42.png)

A arquitetura das classes está estruturada como:

![image](https://user-images.githubusercontent.com/89108219/170899119-f6144bed-b1cd-4a64-833a-a75c93c17044.png)

Infelizmente, após o desligamento do serviço que o professor Thiago Ribeiro Claro criou e manteve para este projeto, não será mais possível criar partidas online contra outras estratégias. Porém, será adicionado o banco de dados no repositório que permitirá que o programa seja executado posteriormente.

## Prints técnicos
Funções da Main:

![image](https://user-images.githubusercontent.com/89108219/170898725-a5bb4be9-90fc-4baa-9b64-875d3a451469.png)

Funções da classe Jogador:

![image](https://user-images.githubusercontent.com/89108219/170899435-37f72eaf-1b14-4d4b-a581-327bce8b4e8a.png)

Funções da classe Partida:

![image](https://user-images.githubusercontent.com/89108219/170899447-8bc6dd95-1f27-425d-85ef-dedd4b3845a9.png)

Funções da classe User:

![image](https://user-images.githubusercontent.com/89108219/170899457-1a24b161-db87-457a-be26-f8fc2abc8b0f.png)

Funções do Form Mão Estratégia:

![image](https://user-images.githubusercontent.com/89108219/170899529-07cc23d3-4548-4fce-babb-b02756ed72b5.png)

## Conclusão
Este foi um projeto que foi desenvolvido em 3 meses e poucos foram os dias em que não houve mudança alguma no código. 

Não deixe de checar os [Insights do repositório](https://github.com/ViniPetra/BodeOfWar/pulse)

A oportunidade de trabalhar tão intensivamente com C# foi fenomenal e foi uma alavanca para muitos conhecimentos em programação que não se limitam à linguagem: Clean code, padrões em funções, OOP, Event oriented programming, Async code, Git, Estruturação de projetos e muitos outros que são incontáveis.

Apesar de muitas frustrações no caminho, foi muito divertido passar por esta experiência e só resta a gratidão de ter feito algo que posso dizer que sinto orgulho.
