-- Generated by CSharp.lua Compiler
local System = System
System.namespace("Slipe.Server.Acl", function (namespace)
  -- <summary>
  -- Struct representing a resource ACL request
  -- </summary>
  namespace.struct("AclRequest", function (namespace)
    local __ctor1__, __ctor2__
    -- <summary>
    -- Create a new ACLRequest
    -- </summary>
    __ctor1__ = function (this, name, access, pending, who, date)
      if access == nil then
        return
      end
      this.Name = name
      this.Access = access
      this.Pending = pending
      this.Who = who
      this.Date = date
    end
    -- <summary>
    -- Create an ACLRequest from an mta request table
    -- </summary>
    __ctor2__ = function (this, request)
      this.Name = request.name
      this.Access = request.access
      this.Pending = request.pending
      this.Who = request.who
      this.Date = request.date
    end
    return {
      Access = false,
      Pending = false,
      __ctor__ = {
        __ctor1__,
        __ctor2__
      },
      __metadata__ = function (out)
        return {
          fields = {
            { "Access", 0x6, System.Boolean },
            { "Date", 0x6, System.String },
            { "Name", 0x6, System.String },
            { "Pending", 0x6, System.Boolean },
            { "Who", 0x6, System.String }
          },
          methods = {
            { ".ctor", 0x506, __ctor1__, System.String, System.Boolean, System.Boolean, System.String, System.String },
            { ".ctor", 0x106, __ctor2__, System.Object }
          }
        }
      end
    }
  end)
end)
