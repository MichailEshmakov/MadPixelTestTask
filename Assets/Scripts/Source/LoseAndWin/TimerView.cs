using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TimeWinner _timeWinner;

    private IEnumerator Start()
    {
        yield return null;
        Fit();

        while (enabled)
        {
            yield return new WaitForSeconds(1);
            Fit();
        }
    }

    private void Fit()
    {
        _text.text = _timeWinner.RemaindTime.ToString();
    }
}
