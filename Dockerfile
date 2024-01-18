FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019
ADD http://go.microsoft.com/fwlink/?linkid=863265 /ndp472-kb4054530-x86-x64-allos-enu.exe
RUN C:\ndp472-kb4054530-x86-x64-allos-enu.exe /quiet /install

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos do projeto para o contêiner
COPY . .

# Restaura as dependências e compila o projeto
RUN nuget restore
RUN msbuild /p:Configuration=Release

# Estágio de execução
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8 AS runtime

# Define o diretório de trabalho para a aplicação em execução
WORKDIR /app

# Copia os arquivos compilados do estágio de compilação
COPY --from=build /app/bin/Release/ .

# Define o comando padrão a ser executado quando o contêiner for iniciado
CMD ["solidWorksApiDev.exe"]
