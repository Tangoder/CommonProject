using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TODOList
{   
    //�U��PhotonNetwork���ͦ��P�}�a ���n�h�@�ӧP�_�O�_��MasterClient�ҥͦ��}�a �_�h�|�X�{�t�@�観Double��T�ǿ�
    //UI Rect Transform�վ�
    //�h�X�ж�state���P -- �F��PUN state
    //���� �ɶ� �ˮ`�P�B -- Call RPC  prototype
    //���a���}�ж� ���赲��e�� -- PhotonNetwork.CurrentRoom.PlayerCount==1 �P�_�ж��H��
    //�����u�������Ĥ@�� -- OntriggerStay & Exit add ��remove List��C or �}�C�j�� �P�_�Z���̪񪺼ĤH
    //��ƹ����� UI��Event Object��OnMouse
    //�}���u���v -- Script Execution Order
    //UI�l��CD --��update�h�]time.deltatime���p�ɾ�fill Image��]�� ��UI��setActive������÷|�v�T��}�����B�� �ҥH�l�ꪺPanel�令Canvas Group�h���}���������
    //UI�l��CD cost�����S�l��]�|������� -- cost���߫���U�l��ᵹ��coldDown = true �h��CD�}���P�_
    //�C�|��FireDelay��waitingTime �|�ɭP��������X�{�l�u�X�h�S����ĤH���{�H -- �̾ڿ��target��update�h�P�_�ĤH�O�_��null
    //Sever�ݥͦ��ǰe��m��T��Client�� �ⵧ��T�|�ɭP�Ǫ�����lag ���x�o�g�����l�u �H�� �Ǫ��Ө��⦸�ˮ` -- �P�_IsMasterClient
    //prefab pool
    //���x�観�D���q �ӧQ����P�_
    //���x�ͩR(�ɶ�) -- timeCountDown + enemyHealthBar
    //�ɯŨt��
    //Ĳ�I�J�I �B��UI���tips
    //����ɯū��q���P�B �����e���|���Y�����P�_
    //�����ݩʪ��ƭ� inspector levelText �l����s �ɯū��s
}
