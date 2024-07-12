using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class EditorManager : BaseManager<Editor,EditorDTO>, IEditorManager
    {
        public EditorManager(IRepository<Editor> iRep, IMapper mapper) : base(iRep, mapper)
        {
        }
    }
}
