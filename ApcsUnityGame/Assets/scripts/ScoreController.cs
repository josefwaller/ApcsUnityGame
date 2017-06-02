using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController {

    public int score = 0;

    public static ScoreController s = new ScoreController();

	public static ScoreController get()
    {
        return s;
    }
}
