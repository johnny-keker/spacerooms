using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class ButtonsPuzzle
    {
        private Terminal _t1;
        private Terminal _t2;
        private Terminal _t3;
        private Terminal _t4;

        private bool _solved = false;
        private Action _onSolve;

        private bool[] _tActive = new bool[] { false, true, false, false };

        public bool Solved => _tActive[0] && _tActive[1] && _tActive[2] && _tActive[3];

        public ButtonsPuzzle(Terminal t1, Terminal t2, Terminal t3, Terminal t4, Action onSolve)
        {
            _onSolve = onSolve;

            _t1 = t1;
            _t2 = t2;
            _t3 = t3;
            _t4 = t4;

            _t1.Setup();
            _t2.Setup();
            _t3.Setup();
            _t4.Setup();

            _t2.SetGreenScreen();

            _t1.OnUse = T1Use;
            _t2.OnUse = T2Use;
            _t3.OnUse = T3Use;
            _t4.OnUse = T4Use;
        }

        private void T1Use()
        {
            if (_solved) return;

            _t1.ToggleScreen();
            _tActive[0] = !_tActive[0];

            _t2.ToggleScreen();
            _tActive[1] = !_tActive[1];

            if (Solved)
            {
                _onSolve();
                _solved = true;
            }
        }

        private void T2Use()
        {
            if (_solved) return;

            _t1.ToggleScreen();
            _tActive[0] = !_tActive[0];

            _t2.ToggleScreen();
            _tActive[1] = !_tActive[1];

            _t3.ToggleScreen();
            _tActive[2] = !_tActive[2];

            if (Solved)
            {
                _onSolve();
                _solved = true;
            }
        }

        private void T3Use()
        {
            if (_solved) return;

            _t2.ToggleScreen();
            _tActive[1] = !_tActive[1];

            _t3.ToggleScreen();
            _tActive[2] = !_tActive[2];

            _t4.ToggleScreen();
            _tActive[3] = !_tActive[3];

            if (Solved)
            {
                _onSolve();
                _solved = true;
            }
        }
        private void T4Use()
        {
            if (_solved) return;

            _t3.ToggleScreen();
            _tActive[2] = !_tActive[2];

            _t4.ToggleScreen();
            _tActive[3] = !_tActive[3];

            if (Solved)
            {
                _onSolve();
                _solved = true;
            }
        }
    }
}
