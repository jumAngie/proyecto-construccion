﻿using Construccion.DataAccess.Repositories.Acce;
using Construccion.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.BusinessLogic.Services
{
    public class AccessService
    {
        private readonly RolesRepository _rolesRepository;
    

        public AccessService(RolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        #region Roles
        public ServiceResult ListRoles()
        {
            var result = new ServiceResult();

            try
            {
                var list = _rolesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult CreateRoles(tbRoles item)
        {
            var result = new ServiceResult();

            try
            {
                var map = _rolesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }


        #endregion

    }
}
