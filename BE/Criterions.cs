﻿using System;
using System.Collections.Generic;

namespace BE
{
    public enum CriterionMode
    {
        passed, Fails, NotDetermined
    }

    public struct Criterion
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }
        public CriterionMode Mode { get => _mode; set => _mode = value; }
        private CriterionMode _mode;

        public Criterion(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _mode = CriterionMode.NotDetermined;
        }
        public Criterion(Criterion criterion)
        {
            _name = criterion.Name;
            _mode = criterion.Mode;
        }
        public Criterion(string name, CriterionMode mode) : this(name)
        {
            Mode = mode;
        }

        public override string ToString()
        {
            return Name + ": " + nameof(Mode);
        }
    }

    public class CriterionsOfTest
    {
        private List<Criterion> _criterions; // solved some issues to do with parsing (if shouldn't be like so, attribute should be changed)

        public CriterionsOfTest()
        {
            Criterions = new List<Criterion>();
            foreach (var i in Configuration.TYPE_OF_CRITERIONS)
            {
                Criterions.Add(new Criterion(i));
            }
        }
        public CriterionsOfTest(CriterionsOfTest criterions)
        {
            this.Criterions = new List<Criterion>(criterions.Criterions);
        }
        public CriterionsOfTest(List<Criterion> criterions)
        {
            Criterions = criterions ?? throw new ArgumentNullException(nameof(criterions));
        }

        public List<Criterion> Criterions { get => _criterions;
            set
            { _criterions = value;
                if (_criterions.FindAll(c => c.Mode != CriterionMode.NotDetermined).Count > 0)
                    _criterions.RemoveAll(c => c.Mode == CriterionMode.NotDetermined);
            }
        }

        public override string ToString()
        {
            string str = "";
            Criterions.ForEach(criterion => str += "| " + criterion);
            return str;
        }
    }
}