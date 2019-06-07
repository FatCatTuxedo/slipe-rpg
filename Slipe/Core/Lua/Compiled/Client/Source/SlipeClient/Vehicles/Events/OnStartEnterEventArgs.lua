-- Generated by CSharp.lua Compiler
local System = System
local SlipeClientPeds
local SlipeSharedElements
System.import(function (out)
  SlipeClientPeds = Slipe.Client.Peds
  SlipeSharedElements = Slipe.Shared.Elements
end)
System.namespace("Slipe.Client.Vehicles.Events", function (namespace)
  namespace.class("OnStartEnterEventArgs", function (namespace)
    local __ctor__
    __ctor__ = function (this, player, seat, door)
      this.Player = SlipeSharedElements.ElementManager.getInstance():GetElement(player, SlipeClientPeds.Player)
      this.Seat = System.cast(System.Int32, seat)
      this.Door = System.cast(System.Int32, door)
    end
    return {
      Seat = 0,
      Door = 0,
      __ctor__ = __ctor__,
      __metadata__ = function (out)
        return {
          properties = {
            { "Door", 0x6, System.Int32 },
            { "Player", 0x6, out.Slipe.Client.Peds.Player },
            { "Seat", 0x6, System.Int32 }
          },
          methods = {
            { ".ctor", 0x304, nil, out.Slipe.MtaDefinitions.MtaElement, System.Object, System.Object }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)
