﻿using SGPTWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.Messages.Departamento
{
    class DocumentoListaMensaje
    {
        public ObservableCollection<DocumentoModelo> listaMensaje { get; set; }
    }
}
