# Criptografia Aes obtendo Secret do Azure KeyVault

API simples, utilizando Spring Boot e Azure OpenAPI modelo Text Davinci 03

## Tecnologias

```
.Net 7
CQRS - Mediatr
Azure KeyVault
Aes Cryptography
```
## Fontes: 
Como provisionar Azure KeyVault->
[How to use Azure Key Vault + .NET Core easily | Secrets, Keys and Certificates](https://www.youtube.com/watch?v=RTq72C10x88)

Comunicação com Azure KeyVault-> [Microsoft Learning Path - Tutorial .net create Vault](https://learn.microsoft.com/pt-br/azure/key-vault/general/tutorial-net-create-vault-azure-web-app)

Sobre o Azure KeyVault-> [Microsoft Learning Path - Key Vault](https://learn.microsoft.com/pt-br/azure/key-vault/general/overview)

Aes Cryptography-> [Microsoft Learning Path - Aes Crypt](https://learn.microsoft.com/pt-br/dotnet/api/system.security.cryptography.aes?view=net-7.0)


<details>

<summary>Exemplo payload</summary>

  
POST http://localhost:5172/api/cryptography/Encrypt
```json
{
	"Message": "Quando a Microsoft foi criada?"
}
```
  
Resposta
```json
{
	"message": "HbvmwhOLHjkdNGrPA3X4EopPOFnHKgLpHH04ce81OH8="
}
```  

POST http://localhost:5172/api/cryptography/Decrypt
```json
{
	"message": "u+Oxl1nxA4j/gLMfqJ3kugHGiN2wyAJyPOcIOZapkYQ="
}
```
  
Resposta
```json
{
	"Message": "Quando a Tesla foi criada?"
}
```    
</details>
