-- Generated by CSharp.lua Compiler
local System = System
local SlipeClientAssets
System.import(function (out)
  SlipeClientAssets = Slipe.Client.Assets
end)
System.namespace("Slipe.Client.Assets", function (namespace)
  namespace.class("CustomAnimation", function (namespace)
    local ApplyTo, OnFileDownload, __ctor__
    __ctor__ = function (this, filepath)
      this.ifp = SlipeClientAssets.Ifp(filepath)
      this.filepath = filepath
    end
    -- <summary>
    -- Downloads and loads the .ifp files into the specified animation block.
    -- </summary>
    ApplyTo = function (this, animationBlock)
      this.animationBlock = animationBlock
      this.ifp.OnDownloadComplete = this.ifp.OnDownloadComplete + System.fn(this, OnFileDownload)
      this.ifp:Download()
    end
    OnFileDownload = function (this)
      this.ifp:Load(this.animationBlock)
    end
    return {
      ApplyTo = ApplyTo,
      __ctor__ = __ctor__,
      __metadata__ = function (out)
        return {
          fields = {
            { "animationBlock", 0x1, System.String },
            { "filepath", 0x1, System.String },
            { "ifp", 0x1, out.Slipe.Client.Assets.Ifp }
          },
          methods = {
            { ".ctor", 0x106, nil, System.String },
            { "ApplyTo", 0x106, ApplyTo, System.String },
            { "OnFileDownload", 0x1, OnFileDownload }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)
