/*                                  ┌∩┐(◣_◢)┌∩┐                              
UnitBehaviour.cs (27/03/2019)                                                 
Autor: Antonio Mateo (.\Moon Antonio)    antoniomt.moon@gmail.com           
Descripcion:    Control del comportamiento de la unidad.                                                             
*/

#region Librerias
using UnityEngine;
using UnityEngine.AI;
#endregion

namespace MoonAntonio
{
    /// <summary>
    /// <para>Control del comportamiento de la unidad. </para>
    /// </summary>
    [HelpURL("https://moonantonio.github.io/"), AddComponentMenu("MoonAntonio/UnitBehaviour")]
    public class UnitBehaviour : MonoBehaviour 
    {
        #region Variables
        /// <summary>
        /// <para>Objetivo del recorrido.</para>
        /// </summary>
        public Transform target;
        /// <summary>
        /// <para>Componente de <see cref="NavMeshAgent"/>.</para>
        /// </summary>
        protected NavMeshAgent agente;
        /// <summary>
        /// <para>Lista de respawns.</para>
        /// </summary>
        public GameObject[] respawns;
        #endregion

        #region Inicializadores
        /// <summary>
        /// <para>Inicializador de <see cref="UnitBehaviour"/>.</para>
        /// </summary>
        private void Start()
        {
            if (this.agente == null) this.agente = this.GetComponent<NavMeshAgent>();
            this.respawns = GameObject.FindGameObjectsWithTag("Respawn");
        }
        #endregion

        #region Actualizadores
        /// <summary>
        /// <para>Actualizador de <see cref="UnitBehaviour"/>.</para>
        /// </summary>
        private void Update()
        {
            this.agente.SetDestination(target.position);
        }
        #endregion

        #region Eventos
        /// <summary>
        /// <para>Cuando entra con otro trigger.</para>
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Finish")
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.position = respawns[Random.Range(0, respawns.Length)].transform.position;
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        #endregion
    }
}