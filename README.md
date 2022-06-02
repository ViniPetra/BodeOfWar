# BodeOfWar
![image](https://user-images.githubusercontent.com/89108219/168502761-1b18a409-87c0-4cbe-8107-7ff528f41dec.png)

Este é um projeto em que foi recriado o jogo Bode Of War em C# usando .NET e Windows Forms como parte do terceiro semestre do curso de Ciências da Computação do SENAC de São Paulo.

Não só a estrutura dos menus e toda as mecânicas de jogo, mas também, um *SISTEMA AUTONOMO* que joga uma partida inteira sozinho!

Alguns prints das telas detro do jogo:

![image](https://user-images.githubusercontent.com/89108219/168503100-54c0de2e-46bf-44d2-be3f-49890181fff2.png)
![image](https://user-images.githubusercontent.com/89108219/168503130-5aaa1a38-68bf-43f2-b7e0-ac2af3415a5d.png)
![image](https://user-images.githubusercontent.com/89108219/168503157-8547b517-6b3e-4312-9de0-e717de318649.png)
![image](https://user-images.githubusercontent.com/89108219/168503179-3dafa30c-2033-4ba1-a82a-6d5e4181285d.png)
![image](https://user-images.githubusercontent.com/89108219/170893814-f1188d71-31ef-4fb2-b992-f6d65a1a2193.png)

Agradecimento especial ao @Yuri-barbosa21, que foi quem fez todas as imagens do projeto

O projeto foi pensado para funcionar de forma extremamente dinâmica.
Só form principal de menus (Main), há 14 paineis com os controles necessários para cada etapa.
Isso permitiu que fossem feitas telas criativas, como os GIFs das telas de tutorial.

O rascunho inicial da dinâmica de tela pode ser acessado aqui: https://xd.adobe.com/view/b89a2cd3-3c15-49ca-8827-7cf1908e99dc-edc9/

Foram usados conceitos de Orientação a Objetos na criação de classes como Cartas, Jogador e Partida e seus respectivos atributos e métodos.

Todas as funções estão comentadas dentro do código e podem ser acessadas caso tenha curiosidade.

A arquitetura das classes está estruturada como:

![image](https://user-images.githubusercontent.com/89108219/170899119-f6144bed-b1cd-4a64-833a-a75c93c17044.png)

A estratégia adotada para o sistema autônomo segue a seguinte lógica:

![image](https://user-images.githubusercontent.com/89108219/170899125-b2e8defd-1a8f-489b-bab2-69dc92557c42.png)

Este foi um projeto bem longo e horas de dedicação que serviu grandiosamente para ganhos de conhecimento em programação e problem-solving skills.

Infelizmente, após o desligamento do serviço que o professor Thiago Ribeiro Claro criou para este projeto, não será mais possível interagir com o programa.

Abaixo deixo a tabela de dependências do Form Main. Uma função de uma fase depende de todas as das fases anteriores.

![image](https://user-images.githubusercontent.com/89108219/170898725-a5bb4be9-90fc-4baa-9b64-875d3a451469.png)

Funções da classe Jogador:

![image](https://user-images.githubusercontent.com/89108219/170899435-37f72eaf-1b14-4d4b-a581-327bce8b4e8a.png)

Funções da classe Partida:

![image](https://user-images.githubusercontent.com/89108219/170899447-8bc6dd95-1f27-425d-85ef-dedd4b3845a9.png)

Funções da classe User:

![image](https://user-images.githubusercontent.com/89108219/170899457-1a24b161-db87-457a-be26-f8fc2abc8b0f.png)

Abaixo deixo a tabela de dependências do Form Mão Estratégia. Uma função de uma fase depende de todas as das fases anteriores.

![image](https://user-images.githubusercontent.com/89108219/170899529-07cc23d3-4548-4fce-babb-b02756ed72b5.png)

