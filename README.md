# Bootcamp Dio - Microsoft Certification Challenge #2 AZ-204
🎯 Objetivo<br>
<p>Projeto tem como objetivo desenvolver um microsserviço(simples) eficiente, escalável e econômico para validação de CPFs, utilizando arquitetura serverless.
A aplicação será construída com base em princípios modernos de computação em nuvem, garantindo alta disponibilidade, baixo custo operacional e facilidade de manutenção.<p>
<br>

📋 Ferramentas necessárias para este projeto:
- [X] Visual Studio Code ou Visual tudio 22.
- [X] Dotnet 8 SDK.
- [X] Azure CLI.
- [X] Azure Functon Core Tolls.

<br>

> [!NOTE]
> No meu caso fiz uso do Visual Studio code.Instalei os seguintes plugins:<br>

  - [X].NET Install Tool
  - [X] Azure Functions(Para trabalhar com - - [X]functions Localmente)
  - [X]Azure Tools - Para ter acesso ao cnsole Azure através do Vs Code.

  <br>

📋 Configurações necessárias para executar este projeto:

<p>Após ter instalado as extenções citadas acima no Vs Code,listarei alguns comandos via terminal no Vs Code.</p>
Observação: Antes de iniciar os comandos abaixo clique no icone Azure(extenção instalada anteriormente) forneça suas credenciais para logar no Azure.

<br>

- [X] Crie uma pasta para conter o projeto no VsCode.Em seguida abra a mesma no VsCode.

- [X] Pressionando simultaneamente o CTR+Shift do Teclado já com sua pasta de trabalho no VsCode selecione:
```vscode
Azure Functions:Create Function App in azure...
```
<br>

**1-) Entre com o nome global da function**<br>
**2-) Selecione a Runtime .Net8 Isolated**<br>
**3-) Selecione a Localização em que o recursao será criado.**<br>
**4-) crie uma pasta com nome  httpvalidacpf(ou qualquer outro que queira):**

```vscode
   mkdir httpvalidacpf
```   

<br>

**5-) Entre pasta criada httpvalidacpf.Em seguida de o seguinte comando:**

```vscode
   func init --worker-runtine dotnet
```

<br>

**6-) De a seguinte instrução para criar a function no Azure.**

```vscode
    func new
```

<br>

. Selecione a seguir httpTrigger.De um nome(fnvalidacpf)
Apóes estes passos ao dar a instrução **func start)** .No fim das mensagens encontrá uma url com qual já poderemos fazer um teste inicial no navegador.Se verificar no Azure já poderá ver o recurso criado.

<br>

O próximo passo e realizar o webDeploy, fazer a publicação:

```vscode 
    func azure functionapp publish funcadrianoaz204
```
<br>
Observação: O nome funcadrianoaz204 é o nome do recurso que foi criado no azure, desta forma verifique antes o nome do recurso criado diretamente no Azure.
Neste momento ele pegrá todo o pacote localmente e fará a publicação no Azure(Provedor Cloud).

<br>

Após o termino do deploy não será mais possível acesso sem authenticação, pois para isso foi gerada uma chave de acesso. A qual pode ser consultada em:
   - acesse a function pelo portal Azure
      - Vá até function
      - App Keys.Nesta pagina será possível veficar a chave **Defaut** a qual faremos uso.
<br>

Localizaçã da Chave no Portal Azure:
![Localizacao](https://github.com/AdrianoProfileAdsCloud/Bootcamp-Microsoft-Certification-Challenge-AZ204/blob/main/images/PortalAzure.png)

<br>

Configurando no Postman:

![Configurando](https://github.com/AdrianoProfileAdsCloud/Bootcamp-Microsoft-Certification-Challenge-AZ204/blob/main/images/Colocar%20chave%20de%20acesso.png)

![params](https://github.com/AdrianoProfileAdsCloud/Bootcamp-Microsoft-Certification-Challenge-AZ204/blob/main/images/Apos%20a%20insercao%20da%20chave.png)






