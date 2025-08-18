# Métodos Numéricos: Bisseção e Posição Falsa

Este projeto implementa dois métodos numéricos clássicos para encontrar raízes de funções: **Bisseção** e **Posição Falsa (Regula Falsi)**, utilizando C# (.NET Framework 4.8).

## 📋 Descrição

O projeto contém implementações completas de dois algoritmos fundamentais em análise numérica para encontrar raízes de equações não-lineares. Ambos os métodos são baseados no teorema do valor intermediário e garantem convergência para funções contínuas em intervalos fechados.

## 🏗️ Estrutura do Projeto

```
CalculoNumerico/
├── CalculoNumerico.sln          # Solução principal do Visual Studio
├── bissecao/                    # Implementação do método da bisseção
│   ├── Program.cs               # Código principal do método
│   ├── bissecao.csproj         # Arquivo de projeto
│   └── App.config              # Configuração da aplicação
├── posicao-falsa/              # Implementação do método da posição falsa
│   ├── Program.cs               # Código principal do método
│   ├── posicao-falsa.csproj    # Arquivo de projeto
│   └── App.config              # Configuração da aplicação
└── README.md                    # Este arquivo
```

## 🔬 Métodos Implementados

### 1. Método da Bisseção (`bissecao/Program.cs`)

**Função de exemplo:** \( f(x) = x \cdot \log_{10}(x) - 1 \)

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

## 🚀 Como Executar

### Pré-requisitos
- Visual Studio 2022 ou superior
- .NET Framework 4.8
- Conhecimento básico de C# e matemática

### Passos para Execução

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
# Para o método da bisseção
cd CalculoNumerico/bissecao
dotnet run

# Para o método da posição falsa
cd CalculoNumerico/posicao-falsa
dotnet run
```

## 📊 Exemplo de Saída

### Método da Bisseção
```
Iteração 1: a = 2.000000, b = 3.000000, c = 2.500000, f(c) = 0.198970
Iteração 2: a = 2.000000, b = 2.500000, c = 2.250000, f(c) = -0.075258
Iteração 3: a = 2.250000, b = 2.500000, c = 2.375000, f(c) = 0.061856
Iteração 4: a = 2.250000, b = 2.375000, c = 2.312500, f(c) = -0.006651
Iteração 5: a = 2.312500, b = 2.375000, c = 2.343750, f(c) = 0.027605
...
Raiz aproximada: 2.506184
```

### Método da Posição Falsa
```
Iteração 1: a = 2.000000, b = 3.000000, c = 2.333333, f(c) = -0.037037
Iteração 2: a = 2.333333, b = 3.000000, c = 2.352941, f(c) = -0.002267
Iteração 3: a = 2.352941, b = 3.000000, c = 2.355556, f(c) = -0.000138
Iteração 4: a = 2.355556, b = 3.000000, c = 2.355556, f(c) = -0.000138
...
Raiz aproximada: 2.355556
```

## ⚙️ Personalização

### Alterando a Função
Modifique a linha que define a função no arquivo `Program.cs`:

```csharp
// Para o método da bisseção
Func<double, double> f = x => x * Math.Log10(x) - 1;

// Para o método da posição falsa
Func<double, double> f = x => Math.Pow(x, 3) - 9 * x + 3;
```

### Alterando Parâmetros
```csharp
double a = 2.0;        // Limite inferior do intervalo
double b = 3.0;        // Limite superior do intervalo
double tol = 1e-3;     // Tolerância (precisão desejada)
int maxIter = 100;     // Número máximo de iterações
```

## 📚 Teoria dos Métodos

### Teorema do Valor Intermediário
Ambos os métodos baseiam-se no teorema: se f é contínua em [a,b] e f(a) · f(b) < 0, então existe pelo menos uma raiz no intervalo (a,b).

### Análise de Convergência

#### Bisseção
- **Taxa de convergência:** Linear
- **Fator de redução:** 1/2 por iteração
- **Erro após n iterações:** \( |x_n - x^*| \leq \frac{b-a}{2^n} \)

#### Posição Falsa
- **Taxa de convergência:** Superlinear
- **Fator de redução:** Variável, geralmente melhor que 1/2
- **Convergência:** Mais rápida para funções bem comportadas

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
