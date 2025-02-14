@echo off

:: Criar a solution
dotnet new sln -n BaseExchange

:: Criar estrutura de pastas e projetos

:: OrderGenerator
mkdir src\OrderGenerator
cd src\OrderGenerator
dotnet new webapi -n BaseExchange.OrderGenerator.Api
dotnet new classlib -n BaseExchange.OrderGenerator.Domain
dotnet new classlib -n BaseExchange.OrderGenerator.Application
dotnet new classlib -n BaseExchange.OrderGenerator.Infrastructure
dotnet new xunit -n BaseExchange.OrderGenerator.Tests
cd ..\..

:: OrderAccumulator
mkdir src\OrderAccumulator
cd src\OrderAccumulator
dotnet new webapi -n BaseExchange.OrderAccumulator.Api
dotnet new classlib -n BaseExchange.OrderAccumulator.Domain
dotnet new classlib -n BaseExchange.OrderAccumulator.Application
dotnet new classlib -n BaseExchange.OrderAccumulator.Infrastructure
dotnet new xunit -n BaseExchange.OrderAccumulator.Tests
cd ..\..

:: Shared
mkdir src\Shared
cd src\Shared
dotnet new classlib -n BaseExchange.Shared.Domain
dotnet new classlib -n BaseExchange.Shared.Infrastructure
cd ..\..

:: Adicionar projetos à solution
dotnet sln add src\OrderGenerator\BaseExchange.OrderGenerator.Api
dotnet sln add src\OrderGenerator\BaseExchange.OrderGenerator.Domain
dotnet sln add src\OrderGenerator\BaseExchange.OrderGenerator.Application
dotnet sln add src\OrderGenerator\BaseExchange.OrderGenerator.Infrastructure
dotnet sln add src\OrderGenerator\BaseExchange.OrderGenerator.Tests

dotnet sln add src\OrderAccumulator\BaseExchange.OrderAccumulator.Api
dotnet sln add src\OrderAccumulator\BaseExchange.OrderAccumulator.Domain
dotnet sln add src\OrderAccumulator\BaseExchange.OrderAccumulator.Application
dotnet sln add src\OrderAccumulator\BaseExchange.OrderAccumulator.Infrastructure
dotnet sln add src\OrderAccumulator\BaseExchange.OrderAccumulator.Tests

dotnet sln add src\Shared\BaseExchange.Shared.Domain
dotnet sln add src\Shared\BaseExchange.Shared.Infrastructure

echo Setup concluído!
