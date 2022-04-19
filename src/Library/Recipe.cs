//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{

    /// <summary>
    /// Para calcular el costo total de producción es necesario saber el precio de cada paso necesario para hacer la receta,
    /// la unica clase que conoce toda esta informacion es recipe, por lo tanto, según expert, esta es la clase correcta
    /// para la responsabilidad de calcular el total.
    /// </summary>
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

         public double GetProductionCost
        {
            get
            {
                double result = 0;
                foreach (Step step in this.steps)
                {
                    result = result + (step.Quantity * step.Input.UnitCost) + (step.Equipment.HourlyCost * step.Time);
                }
                return result;
            }
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Con un costo total de {this.GetProductionCost}");
        }
    }
}
