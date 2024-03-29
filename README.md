# Xoa Slipe RPG

Slipe-Core is a framework that enables anyone to write scripts for [MTA:San Andreas](https://multitheftauto.com) in C# instead of Lua, wrapping all MTA elements and classes and including some .NET Core namespaces. It is based on [CSharp.lua](https://github.com/yanghuan/CSharp.lua) by [Yang Huan](https://github.com/yanghuan).

To fully enhance your development workflow, use [Slipe-CLI](https://github.com/mta-slipe/Slipe-CLI) to create, build and manage your projects.

## Getting Started with coding for Xoa

### Prerequisites


* [.NET Core 3.0 (preview)](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* [Visual studio 2019](https://visualstudio.microsoft.com/downloads/)

Since .NET Core 3.0 is still in preview you need to manually activate it in Visual Studio. You need to also go to Tools > Options > Projects and Solutions > .NET Core and check the Use previews of the .NET Core SDKs checkbox.

### Installation

* Download the latest version of [Slipe-CLI](https://github.com/mta-slipe/Slipe-CLI/releases)
* Clone this repository in your MTA server's resources folder
* Open the Source/Resource.sln solution
* Use the command ```slipe compile``` in the resource folder or simply build the project from Visual Studio

## Need help?

[Slipe Discord](https://discord.gg/sZ3GNPF)
