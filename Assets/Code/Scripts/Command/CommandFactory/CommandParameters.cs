using SignFactory;
using UnityEngine;

namespace MVP.Model
{
    [HelpURL("https://refactoring.guru/introduce-parameter-object")]
    public class CommandParameters
    {
        public DesignDataContainer DesignDataContainer { get; }
        public X_Factory XFactory { get; }
        public O_Factory OFactory { get; }
        public Transform Parent { get; }
        public CellModel Cell { get; }

        public CommandParameters(DesignDataContainer designDataContainer, X_Factory xFactory, O_Factory oFactory, 
            Transform parent, CellModel cell)
        {
            DesignDataContainer = designDataContainer;
            XFactory = xFactory;
            OFactory = oFactory;
            Parent = parent;
            Cell = cell;
        }
    }
}