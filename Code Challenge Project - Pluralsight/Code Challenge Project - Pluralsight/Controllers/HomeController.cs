using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using Code_Challenge_Project___Pluralsight.API;

namespace Code_Challenge_Project___Pluralsight.Controllers
{
    public class HomeController : Controller
    {

        QuestionsController qc = new QuestionsController();
        DB_9CC311_infoalbayraktarEntities db = new DB_9CC311_infoalbayraktarEntities();


        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Index2(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;

            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "" : "Math Operand";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;





            var questions = from s in db.Questions
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {

                int num = Int32.Parse(searchString);
                questions = db.Questions.Where(s => s.FrstOprnd == num
                                       || s.ScndOprnd == num);

                

               // return View(questions.ToList());
            }
            switch (sortOrder)
            {
                
                case "Math Operand":
                    questions = questions.OrderBy(s => s.MthOprnd);
                    break;
                
                default:
                    //return View(db.Questions.ToList());
                    questions = questions.OrderBy(s => s.Qid);
                    break;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(questions.ToPagedList(pageNumber, pageSize));

            //return View(questions.ToList());
        }

    //public ActionResult Index2()
    //{
    //    return View(db.Questions.ToList());
    //}

    public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var  Ques = qc.GetQuestion(id);
            return View(db.Questions.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            Question ques = db.Questions.Find(id);
            return View(ques);
        }
    }
}