using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Care_Taker.Models;
using Care_Taker.Services;

namespace Care_Taker.ViewModels.Validations
{
    internal class CitaDataValidator
    {
        /// <summary>
        /// Compare the <see cref="Cita"/> to be added with the <see cref="IEnumerable{T}"/> of <see cref="Cita"/> that the worker have
        /// </summary>
        /// <param name="Cita"><see cref="Cita"/> to be added.</param>
        /// <param name="Citas"><see cref="List{T}"/><seealso cref="Cita"/> to compare with.</param>
        /// <returns>
        ///     <see langword="true"/> if is the spot is available; <see langword="false"/> if it is not.
        /// </returns>
        public static bool IsAvailable(Cita Cita, IEnumerable<Cita> Citas)
        {
            var list = from cit in Citas where Cita.Fecha.Date.Add(Cita.Hora) >= cit.Fecha.Date.Add(cit.Hora) && Cita.Fecha.Date.Add(Cita.Hora) <= cit.Fecha.Date.Add(cit.Hora).AddMinutes(cit.Tipo.Duracion) select cit;

            return !list.Any();
        }
        /// <summary>
        /// A function to see if the <see cref="Cita"/> is today
        /// </summary>
        /// <param name="Cita">The <see cref="Cita"/> to test.</param>
        /// <returns>
        ///     return <see langword="true"/> if is today; <see langword="false"/> if not.
        /// </returns>
        public static bool IsToday(Cita Cita)
        {
            return Cita.Fecha.Date == DateTime.Today;
        }
        /// <summary>
        /// A function to see if the <see cref="Cita"/> is today but in the past.
        /// </summary>
        /// <param name="Cita">The <see cref="Cita"/> to test.</param>
        /// <returns>
        ///     return <see langword="true"/> if is today in the past; <see langword="false"/> if not.
        /// </returns>
        public static bool IsTodayInPast(Cita Cita)
        {
            if(IsToday(Cita))
            {
                return Cita.Hora < DateTime.Now.TimeOfDay;
            }
            return false;
        }
    }
}
