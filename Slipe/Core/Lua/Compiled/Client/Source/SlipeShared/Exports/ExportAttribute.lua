-- Generated by CSharp.lua Compiler
local System = System
System.namespace("Slipe.Shared.Exports", function (namespace)
  namespace.class("ExportAttribute", function (namespace)
    local __ctor__
    __ctor__ = function (this, name)
      System.base(this).__ctor__(this)
      this.Name = name
    end
    return {
      __inherits__ = function (out)
        return {
          System.Attribute
        }
      end,
      __ctor__ = __ctor__,
      __metadata__ = function (out)
        return {
          properties = {
            { "Name", 0x6, System.String }
          },
          methods = {
            { ".ctor", 0x106, nil, System.String }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)
