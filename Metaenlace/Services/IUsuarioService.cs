﻿using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.Services
{
    public interface IUsuarioService
    {
		public ICollection<Usuario> FindAll();

		public Usuario FindById(long id);

		public bool Save(Usuario usuario);

		public void DeleteById(long id);
	}
}
