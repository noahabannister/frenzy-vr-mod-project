using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour {
    [Tooltip("Use the asset address for the music you want to use for this level. Works with modded content. Addresses can be found in the 'data' lua scripts of other mods.")]
    public string MusicAddress = "";

    public enum BaseMusic { 
        none,
        cabin,
        cruise,
        factory,
        flats,
        home,
        labs,
        nightclub,
        office,
        prison,
        rooftops,
        streets,
        subway,
        underground
    };

    [Tooltip("If the address is left black or the asset cannot be found, this built-in track will be used.")]
    public BaseMusic FallbackMusic;

}
