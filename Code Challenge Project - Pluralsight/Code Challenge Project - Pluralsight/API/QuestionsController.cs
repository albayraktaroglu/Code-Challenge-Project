using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Code_Challenge_Project___Pluralsight;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Code_Challenge_Project___Pluralsight.API
{
    public class QuestionsController : ApiController
    {
        private DB_9CC311_infoalbayraktarEntities db = new DB_9CC311_infoalbayraktarEntities();

        // GET: api/Questions
        public IHttpActionResult GetQuestions()
        {

            try{
                var a = from r in db.Questions
                        select new
                        {
                            qid = r.Qid,
                            op_one = r.FrstOprnd,
                            op_two = r.ScndOprnd,
                            math_op = r.MthOprnd,
                            answr = r.Answer,
                            distractors = from aaa in db.Distractors
                                          where aaa.QID == r.Qid
                                          select new
                                          {
                                              option = aaa.Distrctr
                                          }
                        };
                
                return Ok(a);

            }
            catch (Exception){
                return NotFound();
            }

           
        }


        // GET: api/Questions/5
        public IHttpActionResult GetQuestion(int id)
        {
            try {
                var q = (from c in db.Questions
                         where c.Qid == id
                         select new
                         {
                             qid = c.Qid,
                             op_one = c.FrstOprnd,
                             op_two = c.ScndOprnd,
                             math_op = c.MthOprnd,
                             answr = c.Answer,
                             distractors = from o in db.Distractors
                                           where o.QID == c.Qid
                                           select new
                                           {
                                               option = o.Distrctr
                                           }
                         }).First();
                return Json(q);
                
            } catch (Exception) {

                return NotFound();
            }

           


            //return db.Questions.Find(id);


            //Question question = await db.Questions.FindAsync(id);
            //if (question == null)
            //{
            //    return NotFound();
            //}

            //return Ok(question);
        }


        //Json PUT api
        // PUT: api/Questions/5
        public HttpResponseMessage Put(List<string> val)
        {
            try
            {

                Question newQ = db.Questions.Find(Convert.ToInt32(val[3]));
                newQ.FrstOprnd = Convert.ToInt32(val[0]);
                newQ.ScndOprnd = Convert.ToInt32(val[1]);
                newQ.MthOprnd = val[2];
                

                int answerofnewq = Operator(val[2], Convert.ToInt32(val[0]), Convert.ToInt32(val[1]));
                newQ.Answer = answerofnewq;

                Random rnd;
                foreach (var item in newQ.Distractors)
                {
                    rnd = new Random();
                    item.Distrctr = rnd.Next(1, 4000);
                }

                //assing random options as an answer
                try {
                    newQ.Distractors.ToArray()[new Random().Next(0, newQ.Distractors.Count)].Distrctr = answerofnewq;
                } catch (Exception) {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "bad request");
                }

                
                db.SaveChanges();
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };


            }
            catch (Exception) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "bad request");
            }
        }
        

        // POST: api/Questions
        public HttpResponseMessage PostQuestion(List<string> val)
        {
            //public async Task<IHttpActionResult> 
            if (!val.Any())
            {
                var response = Request.CreateResponse<Question>(HttpStatusCode.NoContent, null);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/Questions/--");
                return response;
            }

            try
            {
                Question obj = new Question();
                obj.FrstOprnd = Convert.ToInt32(val[0]);
                obj.ScndOprnd = Convert.ToInt32(val[1]);
                obj.MthOprnd = val[2];

                Random rndom;
                foreach (var item in obj.Distractors)
                {
                    rndom = new Random();
                    item.Distrctr = rndom.Next(1, 4000);
                }

                //assing random options as an answer

                //might give an error
                int answerofnewq = Operator(val[2], Convert.ToInt32(val[0]), Convert.ToInt32(val[1]));
                obj.Answer = answerofnewq;

                
                int lastrecordquestionnumber = db.Distractors.ToList()[db.Distractors.ToList().Count - 1].QID + 1;
                for (int i = 0; i < 3; i++)
                   
                        obj.Distractors.Add(new Distractor {
                        QID = lastrecordquestionnumber,
                        Distrctr = new Random().Next(1, 4000),
                        Question = obj

                        });

                obj.Distractors.ToArray()[new Random().Next(0, obj.Distractors.Count)].Distrctr = answerofnewq;
               



                db.Questions.Add(obj);
                //await db.SaveChangesAsync();
                db.SaveChanges();


                //var response = Request.CreateResponse<Question>(HttpStatusCode.Created, obj);
               // response.Headers.Location = new Uri(Request.RequestUri, "/api/Questions/" + obj.Qid.ToString());

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, "created");
                return response;

            }
            catch (Exception)
            {
                var response = Request.CreateResponse<Question>(HttpStatusCode.NoContent, null);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/Questions/--");
                return response;
            }


            
            //return Ok();
        }

     
        // DELETE: api/Questions/5
        public async Task<IHttpActionResult> DeleteQuestion(int id)
        {
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            db.Questions.Remove(question);
            await db.SaveChangesAsync();

            return Ok(question);
        }






        private bool QuestionExists(int id)
        {
            return db.Questions.Count(e => e.Qid == id) > 0;
        }

        public static int Operator(string logic, int x, int y)
        {
            switch (logic)
            {
                case "+": return x + y;
                case "-": return x - y;
                case "*": return x * y;
                case "/": return x / y;
                default: throw new Exception("invalid logic");
            }
        }

    }
}