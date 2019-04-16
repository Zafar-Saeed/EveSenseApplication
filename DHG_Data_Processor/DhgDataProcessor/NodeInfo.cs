using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class NodeInfo : IComparable
    {
        public string NodeName { get; set; }
        public short NodeWeight { get; set; }
        
        public bool IsMatch(NodeInfo n)
        {
            return this.NodeName.Equals(n.NodeName);
        }

        public int CompareTo(object obj)
        {
            
            //return NodeName.CompareTo(obj);
            return string.Compare(this.NodeName,((NodeInfo)obj).NodeName,true);
        }

        public NodeInfo(string name, short weight)
        {
            NodeName = name;
            NodeWeight = weight;
        }
               
        public NodeInfo(NodeInfo node)
        {
            NodeName = node.NodeName;
            NodeWeight = node.NodeWeight;
        }
        
    }
}
