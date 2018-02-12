﻿using BTreeFrame;

namespace Battle.Logic.AI.BTree
{
    public class MoveToActionNode : BTreeNodeAction<MyInputData, MyOutputData>
    {
        public MoveToActionNode(BTreeNode<MyInputData, MyOutputData> _parentNode)
            : base(_parentNode)
        {
        }

        protected override BTreeRunningStatus _DoExecute(MyInputData _input, ref MyOutputData _output)
        {
            if (_input.troop.targetKey!=0)
            {
                _output.troop.state = (int)TroopAnimState.Move;
                MoveToTarget(_input, ref _output);
            }
            return BTreeRunningStatus.Finish;
        }

        private void MoveToTarget(MyInputData _input, ref MyOutputData _output)
        {
            var troop = _input.troop;
            var outTroop = _output.troop;
            var target = _input.battleData.mAllTroopDic[troop.targetKey];
            var x = troop.x;
            var y = troop.y;
            var tar_x = target.x;
            var tar_y = target.y;
            if (x > tar_x)
            {
                outTroop.x = x - 1;
                if (outTroop.x < tar_x)
                {
                    outTroop.x = tar_x;
                }
            }
            else if (x < tar_x)
            {
                outTroop.x = x + 1;
                if (outTroop.x > tar_x)
                {
                    outTroop.x = tar_x;
                }
            }
            if (y > tar_y)
            {
                outTroop.y = y - 1;
                if (outTroop.y < tar_y)
                {
                    outTroop.y = tar_y;
                }
            }
            else if (y < tar_y)
            {
                outTroop.y = y + 1;
                if (outTroop.y > tar_y)
                {
                    outTroop.y = tar_y;
                }
            }
        }
    }

}