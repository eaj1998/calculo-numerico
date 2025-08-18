# Cálculo Numérico

Este repositório contém implementações de métodos numéricos para resolução de problemas matemáticos, desenvolvido em C#.

## 📋 Descrição

O projeto implementa algoritmos de cálculo numérico para encontrar raízes de funções. Atualmente, está implementado o **Método da Bisseção**, um método iterativo para encontrar zeros de funções contínuas.

## 🚀 Funcionalidades

- **Método da Bisseção**: Implementação completa do algoritmo para encontrar raízes de funções
- Interface de console para visualização das iterações
- Configurável com tolerância e número máximo de iterações
- Exemplo prático com a função f(x) = x * log₁₀(x) - 1

## 🛠️ Tecnologias

- **C#** (.NET 8.0)
- **Visual Studio** / **Visual Studio Code**
- **Console Application**

## 📁 Estrutura do Projeto

```
calculo-numerico/
├── bissecao/                    # Implementação do método da bisseção
│   ├── bissecao/               # Projeto principal
│   │   ├── Program.cs          # Código principal do algoritmo
│   │   ├── bissecao.csproj     # Arquivo de projeto
│   │   └── bin/                # Arquivos compilados
│   └── Program.cs              # Arquivo de teste
├── CalculoNumerico/            # Solução Visual Studio
│   ├── CalculoNumerico.sln     # Arquivo de solução
│   └── CalculoNumerico.vdproj  # Projeto de deploy
└── README.md                   # Este arquivo
```

## ⚙️ Instalação

### Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- Visual Studio 2022 ou Visual Studio Code

### Passos para execução

1. **Clone o repositório**
   ```bash
   git clone <url-do-repositorio>
   cd calculo-numerico
   ```

2. **Navegue para o projeto**
   ```bash
   cd bissecao/bissecao
   ```

3. **Execute o projeto**
   ```bash
   dotnet run
   ```

## 📖 Como Usar

### Método da Bisseção

O algoritmo implementado resolve a equação:
```
f(x) = x * log₁₀(x) - 1 = 0
```

**Parâmetros configuráveis:**
- `a = 2.0` (limite inferior do intervalo)
- `b = 3.0` (limite superior do intervalo)
- `tol = 1e-3` (tolerância para convergência)
- `maxIter = 100` (número máximo de iterações)

**Saída:**
O programa exibe cada iteração mostrando:
- Número da iteração
- Valores de `a`, `b` e `c` (ponto médio)
- Valor da função no ponto médio `f(c)`
- Raiz aproximada encontrada

## 🔧 Personalização

Para usar com outras funções, modifique a linha no `Program.cs`:

```csharp
// Exemplo: f(x) = x² - 4
Func<double, double> f = x => x * x - 4;

// Exemplo: f(x) = sin(x)
Func<double, double> f = x => Math.Sin(x);
```

Ajuste também os intervalos `a` e `b` para garantir que f(a) e f(b) tenham sinais opostos.

## 📚 Teoria

### Método da Bisseção

O método da bisseção é um algoritmo de busca de raízes que divide repetidamente um intervalo ao meio e seleciona o subintervalo que contém a raiz.

**Algoritmo:**
1. Verifica se f(a) e f(b) têm sinais opostos
2. Calcula o ponto médio c = (a + b) / 2
3. Avalia f(c)
4. Se |f(c)| < tolerância, retorna c como raiz
5. Caso contrário, atualiza o intervalo [a, b] baseado no sinal de f(c)
6. Repete até convergência ou número máximo de iterações

**Vantagens:**
- Simples de implementar
- Sempre converge para uma raiz
- Não requer cálculo de derivadas

**Desvantagens:**
- Convergência linear (mais lento que outros métodos)
- Requer intervalo inicial com sinais opostos

## 🤝 Contribuição

Contribuições são bem-vindas! Para contribuir:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 👨‍💻 Autor

Desenvolvido como parte de estudos em cálculo numérico.

## 📞 Suporte

Para dúvidas ou sugestões, abra uma issue no repositório.

---

**Nota**: Este projeto é destinado a fins educacionais e de aprendizado em métodos numéricos.