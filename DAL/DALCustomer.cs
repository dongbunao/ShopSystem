﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCustomer : BaseRepository<tb_Customer>, IDAL.IDALCustomer
    {
    }
}
