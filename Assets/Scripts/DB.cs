using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Runtime.CompilerServices;
using System;
using UnityEngine.InputSystem.Layouts;

public class DB : MonoBehaviour
{
    public GameObject schoolPopup;
    public GameObject notInSchool;
    public Text distancebtw;
    public bool isFirst = false;
    public InputField inputField;
    public Text playernameSyncronize;
    public class Place
    {
        public string name;
        public float x;
        public float y;

        public Place()
        {

        }

        public Place(string name, float x, float y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
    }

    DatabaseReference reference;

    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        writeStore("1", "Politech School", 37.477379f, 126.862621f);
        writeStore("2", "Children's Grand Park", 37.549485f, 127.081826f);
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    testinputField.text = inputField.text;
        //}
    }

    public void enterPlayerName()
    {
        playernameSyncronize.text = inputField.text;
    }

    void writeStore(string placeId, string name, float x, float y)
    {
        Place place = new Place(name, x, y);
        string str = JsonUtility.ToJson(place);

        // db�� ���� ���� ���� �Լ� : SetRawJsonValueAsync
        
        if(placeId == "1")
        {
            reference.Child("School").Child(placeId).SetRawJsonValueAsync(str);

        }
        else if(placeId == "2")
        {
            reference.Child("Park").Child(placeId).SetRawJsonValueAsync(str);
        }
    }

    // School ���� ��ġ �о����
    public void confirmSchoolLocation()
    {
        FirebaseDatabase.DefaultInstance.GetReference("School").GetValueAsync().ContinueWithOnMainThread(
            task =>
            {
                if (task.IsFaulted)
                {

                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    foreach (DataSnapshot data in snapshot.Children)
                    {
                        string value = data.GetRawJsonValue();
                        Place place = JsonUtility.FromJson<Place>(value);

                        // db�� gps ��ġ �Ѵ� �ʿ�
                        Vector2 dbPos = new Vector2(place.x, place.y);

                        Vector2 gpsPos = GetComponent<GPS>().GetGPSInfo();
                        double ramainDistance = distance(gpsPos.x, gpsPos.y, dbPos.x, dbPos.y);

                        distancebtw.text = "�� �� ���� �Ÿ� : " + ramainDistance;

                        // 50m �̳��� �˾�â ����
                        if(ramainDistance < 50f)
                        {
                            if (!isFirst)
                            {
                                isFirst = true;
                                schoolPopup.SetActive(true);
                            }
                        }
                        else
                        {
                            notInSchool.SetActive(true);
                        }

                    }

                }
            }
            );
    }

    // ���� ��ó�� �ִ��� Ȯ���ϴ� �Լ�
    public void confirmParkLocation()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Park").GetValueAsync().ContinueWithOnMainThread(
            task =>
            {
                if (task.IsFaulted)
                {

                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    foreach (DataSnapshot data in snapshot.Children)
                    {
                        string value = data.GetRawJsonValue();
                        Place place = JsonUtility.FromJson<Place>(value);

                        // db�� gps ��ġ �Ѵ� �ʿ�
                        Vector2 dbPos = new Vector2(place.x, place.y);

                        Vector2 gpsPos = GetComponent<GPS>().GetGPSInfo();
                        double ramainDistance = distance(gpsPos.x, gpsPos.y, dbPos.x, dbPos.y);

                        distancebtw.text = "�� �� ���� �Ÿ� : " + ramainDistance;

                        // 50m �̳��� �˾�â ����
                        if (ramainDistance < 50f)
                        {
                            if (!isFirst)
                            {
                                isFirst = true;
                                schoolPopup.SetActive(true);
                            }
                        }
                        else
                        {
                            notInSchool.SetActive(true);
                        }

                    }

                }
            }
            );
    }

    // ��ǥ�� �Ÿ� ��� ����(�Ϲ����� ����)
    private double distance(double lat1, double lon1, double lat2, double lon2)
    {
        double theta = lon1 - lon2;

        double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));

        dist = Math.Acos(dist);

        dist = Rad2Deg(dist);

        dist = dist * 60 * 1.1515;

        dist = dist * 1609.344; // ���� ��ȯ

        return dist;
    }

    private double Deg2Rad(double deg)
    {
        return (deg * Mathf.PI / 180.0f);
    }

    private double Rad2Deg(double rad)
    {
        return (rad * 180.0f / Mathf.PI);
    }

    //public void CreateStoreCharacter(Vector2 gpsPos, Transform image)
    //{
    //    FirebaseDatabase.DefaultInstance.GetReference("Places").GetValueAsync().ContinueWithOnMainThread(
    //        task =>
    //        {
    //            if(task.IsFaulted)
    //            {

    //            }
    //            else if(task.IsCompleted)
    //            {

    //                DataSnapshot snapshot = task.Result;
    //                foreach(DataSnapshot data in snapshot.Children)
    //                {
    //                    // db���� ���� �о�� �� ���� �Լ� : GetRawJsonValue
    //                    string value = data.GetRawJsonValue();
    //                    // �츮�� ���� �� json Ÿ������ �����ͼ� ���� ���� class Ÿ���� ��ȯ���ش�. 
    //                    Place place = JsonUtility.FromJson<Place>(value);

    //                    Vector2 dbPos = new Vector2(place.x, place.y);
    //                    float d = Vector2.Distance(dbPos, gpsPos);

    //                    destinationText.text = "���� ����" + d;
    //                    //500m
    //                    if (d<0.0005f)
    //                    {
    //                        //�̰� ������ ������ �ǰ�?(�̰� ���� �غ���) ������� �ϳ�?? �������̾�?
    //                        // ���� ���� �̹����� �ϳ��� �׷���???
    //                        //GameObject prefab = Resources.Load(store.name) as GameObject;
    //                        //Instantiate(prefab, image.position, image.rotation);

    //                        // �� �� ������ �Լ��� �۵��� �� �ұ�?(�� �𸣰ڴ�.)
    //                        StatusWindow.SetActive(true);
    //                        destinationText.text = "���忡 �����ϼ̽��ϴ�.";
    //                    }
    //                }

    //            }
    //        }
    //    );
    //}


}
