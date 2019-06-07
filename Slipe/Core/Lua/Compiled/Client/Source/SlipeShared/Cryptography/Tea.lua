-- Generated by CSharp.lua Compiler
local System = System
local SlipeMtaDefinitions
local DictStringString
System.import(function (out)
  SlipeMtaDefinitions = Slipe.MtaDefinitions
  DictStringString = System.Dictionary(System.String, System.String)
end)
System.namespace("Slipe.Shared.Cryptography", function (namespace)
  -- <summary>
  -- Represents static wrappers for the Tiny Encryption Algorithm
  -- </summary>
  namespace.class("Tea", function (namespace)
    local Encrypt, Decrypt
    -- <summary>
    -- Encrypt a string with the Tiny Encryption Algorithm
    -- </summary>
    Encrypt = function (input, key)
      local options = DictStringString()
      options:set("key", key)
      return SlipeMtaDefinitions.MtaShared.EncodeString("tea", input, options)
    end
    -- <summary>
    -- Decrypt an encrypted string with the Tiny Encryption Algorithm
    -- </summary>
    Decrypt = function (input, key)
      local options = DictStringString()
      options:set("key", key)
      return SlipeMtaDefinitions.MtaShared.DecodeString("tea", input, options)
    end
    return {
      Encrypt = Encrypt,
      Decrypt = Decrypt,
      __metadata__ = function (out)
        return {
          methods = {
            { "Decrypt", 0x28E, Decrypt, System.String, System.String, System.String },
            { "Encrypt", 0x28E, Encrypt, System.String, System.String, System.String }
          },
          class = { 0xE }
        }
      end
    }
  end)
end)
