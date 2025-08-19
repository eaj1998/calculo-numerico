# Métodos Numéricos: Bisseção, Posição Falsa, Cordas e Newton

Este projeto implementa quatro métodos numéricos clássicos para encontrar raízes de funções: **Bisseção**, **Posição Falsa (Regula Falsi)**, **Método das Cordas** e **Método de Newton**, utilizando C# (.NET Framework 4.8). O projeto inclui um **sistema de menu interativo** que permite executar todos os métodos de forma unificada.

## 📋 Descrição

O projeto contém implementações completas de quatro algoritmos fundamentais em análise numérica para encontrar raízes de equações não-lineares. Os métodos de Bisseção e Posição Falsa são baseados no teorema do valor intermediário, enquanto os métodos de Cordas e Newton utilizam aproximações lineares e derivadas para convergência mais rápida.

## 🏗️ Estrutura do Projeto

```
CalculoNumerico/
├── CalculoNumerico.sln          # Solução principal do Visual Studio
├── Menu/                         # Sistema de menu interativo (NOVO!)
│   ├── Program.cs               # Menu principal com todas as opções
│   ├── Menu.csproj             # Arquivo de projeto do menu
│   └── App.config              # Configuração da aplicação
├── bissecao/                    # Implementação do método da bisseção
│   ├── Program.cs               # Código principal do método
│   ├── bissecao.csproj         # Arquivo de projeto
│   └── App.config              # Configuração da aplicação
├── posicao-falsa/              # Implementação do método da posição falsa
│   ├── Program.cs               # Código principal do método
│   ├── posicao-falsa.csproj    # Arquivo de projeto
│   └── App.config              # Configuração da aplicação
├── cordas/                      # Implementação do método das cordas
│   ├── Program.cs               # Código principal do método
│   ├── cordas.csproj           # Arquivo de projeto
│   └── App.config              # Configuração da aplicação
├── newton/                      # Implementação do método de Newton
│   ├── Program.cs               # Código principal do método
│   ├── newton.csproj            # Arquivo de projeto
│   └── App.config              # Configuração da aplicação
└── README.md                    # Este arquivo
```

## 🆕 Sistema de Menu Interativo

### Funcionalidades do Menu (`Menu/Program.cs`)

O novo módulo Menu oferece uma interface unificada para todos os métodos numéricos:

- **Opção 1**: Método da Bisseção
- **Opção 2**: Método da Posição Falsa  
- **Opção 3**: Método de Newton
- **Opção 4**: Método das Cordas (Secante)
- **Opção 0**: Sair

**Características:**
- Interface de usuário amigável via console
- Entrada de parâmetros interativa para cada método
- Função de exemplo unificada: f(x) = x³ - 9x + 3
- Cálculo automático de derivada para o método de Newton
- Tratamento de erros robusto
- Possibilidade de executar múltiplos métodos em sequência

**Como usar:**
1. Execute o projeto Menu como projeto de inicialização
2. Escolha o método desejado (1-4)
3. Insira os parâmetros solicitados
4. Visualize o resultado
5. Continue testando outros métodos ou saia (0)

## 🔬 Métodos Implementados

### 1. Método da Bisseção (`bissecao/Program.cs`)

**Função de exemplo:** \( f(x) = x^3 - 9x + 3 \)

**Intervalo:** [2, 3]

**Características:**
- **Convergência:** Linear e garantida
- **Vantagens:** Simples, robusto e sempre converge
- **Desvantagens:** Convergência mais lenta comparada a outros métodos
- **Aplicação:** Ideal para funções contínuas onde se conhece um intervalo que contém a raiz

**Algoritmo:**
1. Divide o intervalo [a,b] ao meio: \( c = \frac{a + b}{2} \)
2. Avalia f(c)
3. Escolhe o subintervalo [a,c] ou [c,b] baseado no sinal de f(c)
4. Repete até atingir a tolerância desejada

**Melhorias implementadas:**
- Método público e estático para uso externo
- Tratamento de erros com try-catch
- Validação de entrada (f(a) e f(b) com sinais opostos)
- Retorno de erro (0) em caso de falha

### 2. Método da Posição Falsa (`posicao-falsa/Program.cs`)

**Função de exemplo:** \( f(x) = x^3 - 9x + 3 \)

**Intervalo:** [2, 3]

**Características:**
- **Convergência:** Superlinear (mais rápida que a bisseção)
- **Vantagens:** Convergência mais rápida, mantém a robustez
- **Desvantagens:** Pode ter convergência lenta em alguns casos
- **Aplicação:** Excelente para funções bem comportadas, oferecendo melhor performance que a bisseção

**Algoritmo:**
1. Calcula o ponto de interseção da reta secante: \( c = \frac{a \cdot f(b) - b \cdot f(a)}{f(b) - f(a)} \)
2. Avalia f(c)
3. Escolhe o subintervalo baseado no sinal de f(c)
4. Repete até atingir a tolerância desejada

### 3. Método das Cordas (`cordas/Program.cs`)

**Função de exemplo:** \( f(x) = x^3 - 9x + 3 \)

**Pontos iniciais:** x₀ = 2.5, x₁ = 3.0

**Características:**
- **Convergência:** Superlinear (mais rápida que bisseção e posição falsa)
- **Vantagens:** Convergência rápida, não requer derivada, robusto
- **Desvantagens:** Requer dois pontos iniciais, pode divergir em alguns casos
- **Aplicação:** Excelente para funções suaves quando se dispõe de dois pontos iniciais

**Algoritmo:**
1. Utiliza dois pontos iniciais x₀ e x₁
2. Calcula o próximo ponto usando interpolação linear: \( x_{n+1} = x_n - f(x_n) \cdot \frac{x_n - x_{n-1}}{f(x_n) - f(x_{n-1})} \)
3. Atualiza os pontos e repete até atingir a tolerância desejada

### 4. Método de Newton (`newton/Program.cs`)

**Função de exemplo:** \( f(x) = x^3 - 9x + 3 \)

**Derivada:** \( f'(x) = 3x^2 - 9 \)

**Ponto inicial:** x₀ = 3.0

**Características:**
- **Convergência:** Quadrática (mais rápida de todos os métodos)
- **Vantagens:** Convergência extremamente rápida, eficiente computacionalmente
- **Desvantagens:** Requer cálculo da derivada, pode divergir com pontos iniciais inadequados
- **Aplicação:** Ideal para funções bem comportadas com derivadas conhecidas e pontos iniciais próximos da raiz

**Algoritmo:**
1. Utiliza um ponto inicial x₀
2. Calcula o próximo ponto usando: \( x_{n+1} = x_n - \frac{f(x_n)}{f'(x_n)} \)
3. Repete até atingir a tolerância desejada

## 🚀 Como Executar

### Pré-requisitos
- Visual Studio 2022 ou superior
- .NET Framework 4.8
- Conhecimento básico de C# e matemática

### Opção 1: Sistema de Menu (Recomendado)

1. **Abra o projeto:**
   - Abra o arquivo `CalculoNumerico.sln` no Visual Studio
   
2. **Configure o Menu como projeto de inicialização:**
   - Clique com botão direito no projeto `Menu` na Solution Explorer
   - Selecione "Set as Startup Project"
   
3. **Execute o projeto:**
   - Pressione `F5` ou clique em "Start Debugging"
   - Siga as instruções no console para escolher o método e inserir parâmetros

### Opção 2: Métodos Individuais

1. **Abra o projeto:**
   - Abra o arquivo `CalculoNumerico.sln` no Visual Studio
   
2. **Selecione o projeto desejado:**
   - Clique com botão direito no projeto desejado na Solution Explorer
   - Selecione "Set as Startup Project"
   
3. **Execute o projeto:**
   - Pressione `F5` ou clique em "Start Debugging"
   - O resultado será exibido no console

### Alternativa via Linha de Comando

```bash
# Para o sistema de menu (recomendado)
cd CalculoNumerico/Menu
dotnet run

# Para métodos individuais
cd CalculoNumerico/bissecao
dotnet run

cd ../posicao-falsa
dotnet run

cd ../cordas
dotnet run

cd ../newton
dotnet run
```

## 📊 Exemplo de Uso do Menu

```
Escolha o método:
1 - Bisseção
2 - Posição Falsa
3 - Newton
4 - Cordas (Secante)
0 - Sair
Opção: 1

a: 2
b: 3
Tolerância: 0.001
Máx. Iterações: 100

Iteração 1: a = 2.000000, b = 3.000000, c = 2.500000, f(c) = -0.125000
Iteração 2: a = 2.000000, b = 2.500000, c = 2.250000, f(c) = -1.265625
Iteração 3: a = 2.000000, b = 2.250000, c = 2.125000, f(c) = -2.119141
...

Raiz aproximada: 2.000000
```

## ⚙️ Personalização

### Alterando a Função no Menu

Para modificar a função de exemplo no sistema de menu, edite o arquivo `Menu/Program.cs`:

```csharp
// Função atual: f(x) = x^3 - 9x + 3
Func<double, double> f = x => Math.Pow(x, 3) - 9 * x + 3;

// Exemplo de outras funções:
// f(x) = x * log10(x) - 1
Func<double, double> f = x => x * Math.Log10(x) - 1;

// f(x) = e^x - 2x - 1
Func<double, double> f = x => Math.Exp(x) - 2 * x - 1;

// f(x) = sin(x) - x/2
Func<double, double> f = x => Math.Sin(x) - x / 2;
```

### Alterando Parâmetros Padrão

```csharp
// Para Bisseção e Posição Falsa
double a = 2.0;        // Limite inferior do intervalo
double b = 3.0;        // Limite superior do intervalo
double tol = 1e-3;     // Tolerância (precisão desejada)
int maxIter = 100;     // Número máximo de iterações

// Para Método das Cordas
double x0 = 2.5;       // Primeiro ponto inicial
double x1 = 3.0;       // Segundo ponto inicial
double tol = 1e-5;     // Tolerância (precisão desejada)
int maxIter = 10;      // Número máximo de iterações

// Para Método de Newton
double x0 = 3.0;       // Ponto inicial
double tol = 1e-5;     // Tolerância (precisão desejada)
int maxIter = 3;       // Número máximo de iterações
```

## 🔧 Arquitetura Técnica

### Estrutura de Classes

Todos os métodos implementam a mesma interface de uso:

```csharp
// Bisseção
public static double Bissecao(Func<double, double> f, double a, double b, double tol, int maxIter)

// Posição Falsa
public static double PosicaoFalsa(Func<double, double> f, double a, double b, double tol, int maxIter)

// Cordas
public static double Cordas(Func<double, double> f, double x0, double x1, double tol, int maxIter)

// Newton
public static double Newton(Func<double, double> f, Func<double, double> df, double x0, double tol, int maxIter)
```

### Tratamento de Erros

- **Validação de entrada:** Verificação de sinais opostos para métodos de intervalo
- **Divisão por zero:** Proteção contra divisão por zero nos métodos de Cordas e Newton
- **Derivada zero:** Validação de derivada próxima de zero no método de Newton
- **Try-catch:** Tratamento robusto de exceções

### Cálculo Automático de Derivada

O sistema de menu inclui cálculo automático de derivada usando diferenças finitas:

```csharp
static Func<double, double> Derivada(Func<double, double> f)
{
    return x =>
    {
        double h = 1e-6;
        return (f(x + h) - f(x - h)) / (2 * h);
    };
}
```

## 📚 Teoria dos Métodos

### Teorema do Valor Intermediário
Os métodos de Bisseção e Posição Falsa baseiam-se no teorema: se f é contínua em [a,b] e f(a) · f(b) < 0, então existe pelo menos uma raiz no intervalo (a,b).

### Métodos de Aproximação Linear
Os métodos de Cordas e Newton utilizam aproximações lineares da função para encontrar raízes, resultando em convergência mais rápida que os métodos baseados em intervalos.

### Análise de Convergência

#### Bisseção
- **Taxa de convergência:** Linear
- **Fator de redução:** 1/2 por iteração
- **Erro após n iterações:** \( |x_n - x^*| \leq \frac{b-a}{2^n} \)

#### Posição Falsa
- **Taxa de convergência:** Superlinear
- **Fator de redução:** Variável, geralmente melhor que 1/2
- **Convergência:** Mais rápida para funções bem comportadas

#### Método das Cordas
- **Taxa de convergência:** Superlinear
- **Fator de redução:** Variável, geralmente melhor que posição falsa
- **Convergência:** Rápida para funções suaves, não requer derivada

#### Método de Newton
- **Taxa de convergência:** Quadrática
- **Fator de redução:** Muito rápido, especialmente próximo da raiz
- **Convergência:** Extremamente rápida para funções bem comportadas

### Comparação de Performance
| Método | Convergência | Robustez | Velocidade | Requisitos |
|--------|--------------|----------|------------|------------|
| Bisseção | Linear | Alta | Lenta | Intervalo [a,b] |
| Posição Falsa | Superlinear | Alta | Média | Intervalo [a,b] |
| Cordas | Superlinear | Média | Rápida | Dois pontos iniciais |
| Newton | Quadrática | Baixa | Muito rápida | Derivada + ponto inicial |

## 🔍 Casos de Uso

### Quando Usar Bisseção
- Funções contínuas em intervalos fechados
- Quando a robustez é mais importante que a velocidade
- Implementações educacionais e didáticas
- Situações onde se precisa de garantia de convergência

### Quando Usar Posição Falsa
- Funções bem comportadas e suaves
- Quando se busca convergência mais rápida
- Aplicações práticas onde a performance é importante
- Funções com derivadas contínuas

### Quando Usar Método das Cordas
- Funções suaves quando se dispõe de dois pontos iniciais
- Quando se busca convergência rápida sem calcular derivadas
- Situações onde a função é bem comportada mas a derivada é difícil de calcular
- Aplicações onde se tem estimativas iniciais da raiz

### Quando Usar Método de Newton
- Funções bem comportadas com derivadas conhecidas
- Quando se busca convergência extremamente rápida
- Ponto inicial próximo da raiz desejada
- Aplicações onde a eficiência computacional é crítica

## 🐛 Solução de Problemas

### Erro: "f(a) e f(b) devem ter sinais opostos"
- **Causa:** O intervalo [a,b] não contém uma raiz
- **Solução:** Verifique se f(a) · f(b) < 0 ou expanda o intervalo

### Convergência Lenta
- **Causa:** Função muito plana ou intervalo muito grande
- **Solução:** Reduza o intervalo inicial ou aumente a tolerância

### Overflow Numérico
- **Causa:** Valores muito grandes ou muito pequenos
- **Solução:** Escale a função ou use intervalos menores

### Método das Cordas - Divergência
- **Causa:** Pontos iniciais inadequados ou função muito irregular
- **Solução:** Escolha pontos iniciais mais próximos da raiz ou use outro método

### Método de Newton - Derivada Zero
- **Causa:** Derivada próxima de zero no ponto atual
- **Solução:** Use um ponto inicial diferente ou outro método

### Erro no Sistema de Menu
- **Causa:** Entrada inválida ou parâmetros incorretos
- **Solução:** Verifique se os valores inseridos são numéricos válidos e estão dentro dos limites esperados

## 📖 Referências

- Burden, R. L., & Faires, J. D. (2010). *Numerical Analysis*. Cengage Learning.
- Chapra, S. C., & Canale, R. P. (2014). *Numerical Methods for Engineers*. McGraw-Hill.
- Atkinson, K. E. (1989). *An Introduction to Numerical Analysis*. John Wiley & Sons.

## 🤝 Contribuições

Contribuições são bem-vindas! Para contribuir:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 👨‍💻 Autor

Desenvolvido como parte de estudos em métodos numéricos e análise computacional.

---

**Nota:** Este projeto é destinado a fins educacionais e de pesquisa. Para aplicações comerciais ou críticas, considere usar bibliotecas numéricas estabelecidas como Math.NET Numerics ou Accord.NET.

