void Start()
    {
        InvokeRepeating("getData", 2.0f, 2.0f);
    }

void getData()
    {
        playerdata.position3D[0] = transform.position.x;
        playerdata.position3D[1] = transform.position.y;
        playerdata.position3D[2] = transform.position.z;
        playerdata.tag = canv.GetComponent<GetInputOnClick>().input.text;
        StartCoroutine(playerdata.SavePlayerData(result => {Debug.Log(result);}));
    }
