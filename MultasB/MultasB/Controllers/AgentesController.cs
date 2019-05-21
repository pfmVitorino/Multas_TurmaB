using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultasB.Models;

namespace MultasB.Controllers
{
    public class AgentesController : Controller
    {
        private MultasDB db = new MultasDB();

        // GET: Agentes
        public ActionResult Index()
        {
            return View(db.Agentes.ToList());
        }

        // GET: Agentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Agentes agente = db.Agentes.Find(id);
            if (agente == null)
            {
                return RedirectToAction("Index");
            }
            Session["Metodo"] = "";


            return View(agente);
        }

        // GET: Agentes/Create
        /// <summary>
        /// Mostra a view para carregar os dados de um novo agente 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Recolhe os dados da view sobre um novo agente
        /// </summary>
        /// <param name="agente">dados do novo agente</param>
        /// <param name="uploadFotografia">ficheiro com a foto do novo agente</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Esquadra")] Agentes agente, HttpPostedFileBase uploadFotografia)
        {  
            /// 1º será que foi enviado um ficheiro?
            /// 2º será que o ficheiro, se foi fornecido, é do tipo correto?
            /// 3º qual o nome que devo dar ao ficheiro?
            /// 4º como o associar ao novo Agente?
            /// 5º como o guardar no disco rígido?






            // confronta os dados que vem da view com a forma que os dados devem  ter .
            // ie, valida os dados com o modelo
            if (ModelState.IsValid)
            {
                try
                {
                    db.Agentes.Add(agente);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {


                }
              
            }

            return View(agente);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        /// <summary>
        /// mostra na view os dados de um agente para, depois, remover o mesmo
        /// </summary>
        /// <param name="id"> identificador do agente a remover</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            // o ID do agente não foi fornecido 
            // não é possivel procurar o agente 
            // o que devo fazer?
            if (id == null)
            {
                // opção por defeito do 'template'
                //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                // e não há ID do Agente, uma de duas coisas aconteceu:
                // - há um erro nos links da aplicação
                // - há um 'chico esperto' a fazer asneira no URL

                // redireciono o utilizador para o ecrã inicial
                return RedirectToAction("Index");
         
            }

            
            // procura os dados do agente cujo o ID é fornecido
            Agentes agente = db.Agentes.Find(id);


            // se o agente não for encontrado 
               if (agente == null)
            {// ou há um erro, ou há um 'chico esperto' ....
             // return HttpNotFound();

                // redireciono o utilizador para o ecrã inicial
                return RedirectToAction("Index");
            }
            // para o caso do utilizador alterar, de forma fraudulenta os dados do Agente,vamos guardá-os internamente 
            // para isso , vou guardar o valor  do ID do agente 
            // - guardar o ID do agente num cookie cifrado
            // - guardar o ID numa var. de sessão(quem estiver a usar o ASP.net Core já não tem esta ferramenta...)
            // - outras opções...
            Session["IdAgente"] = agente.ID;
            Session["Metodo"] = "Agentes/Delete";






            // envia para a view os dados do agente 
            return View(agente);
        }

        // POST: Agentes/Delete/5
        /// <summary>
        /// concretizar a operação de remoção de um agente
        /// </summary>
        /// <param name="id">identificador do agente</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null) {
                // se entrei aqui é porque existe um erro
                // não se sabe o ID do agente a remover
                return RedirectToAction("Index");
            }

            // avaliar se o ID do agente que é fornecido é o mesmo ID do agente que foi apresentado no ecrã
            if (id!=(int) Session["IdAgente"]) {
                // há um ataque!
                // redireconar para a página do Index
                return RedirectToAction("Index");

            }
            // avaliar se o metedo é o que é esperado
            string operacao = "Agentes/Delete";
            if (operacao != (string)Session["Metodo"])
            {
                // há um ataque!
                // redireconar para a página do Index
                return RedirectToAction("Index");

            }
            // procura os dados do agente, na BD
            Agentes agente = db.Agentes.Find(id);

            if (agente == null) {
                // náo foi possivel encontrar o Agente 
                return RedirectToAction("Index");
            }
            try
            {
                db.Agentes.Remove(agente);
                db.SaveChanges();
            }
            catch (Exception)
            {// captura a excessão e processa o código para resolver o problema
             // pode haver mais do que um 'cath' associado a um 'try'

                // enviar mensagem de erro para o utilizador

                ModelState.AddModelError("","Ocorreu um erro com a eliminação do Agente "
                                         + agente.Nome+". Provavelmente relacionado com o facto do " +
                                         " agente ter emitido multas...");
                // devolver os dados do agente á View
                return View(agente);
            }
            
            // redireciona o interface para a view INDEX associada ao controller Agentes
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
