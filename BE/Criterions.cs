using System;
using System.Collections.Generic;
namespace BE
{
    public enum CriterionMode
    {
        passed, Fails, NotDetermined
    }
    
    public struct Criterion
    {
        string _name;
        public string Name { get => _name; set => _name = value; }
        public CriterionMode Mode { get => _mode; set => _mode = value; }
        CriterionMode _mode;
        public Criterion(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _mode = CriterionMode.NotDetermined;
        }

    }
    public class CriterionsOfTest
    {
        private List<Criterion> _criterions; // solved some issues to do with parsing (if shouldn't be like so, attribute should be changed)
        public CriterionsOfTest()
        {

            foreach(var i in Configuration.TYPE_OF_CRITERIONS)
            {
                Criterions.Add(new Criterion(i));
            }
         }

        public List<Criterion> Criterions { get => _criterions; set => _criterions = value; }
    }
}