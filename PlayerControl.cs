using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // menggerakan keatas
    public KeyCode upButton = KeyCode.W;

    // menggerakan kebawah
    public KeyCode downButton = KeyCode.S;

    // kecepatan gerak
    public float speed = 10.0f;

    // Batas atas dan bawah game scene(batas bawah menggunakan minus(-))
    public float yBoundary = 9.0f;

    // rigidbody raket
    private Rigidbody2D rigidbody2D;

    //skor pemain
    private int score;

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;




    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //kecepatan raket saat ini
        Vector2 velocity = rigidbody2D.velocity;

        //jika klik tombol w maka diberi kecepatan komponen y +, tapi jika S maka diberi komponen y -
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else 
        {
            velocity.y = 0.0f;
        }

        rigidbody2D.velocity = velocity;



        // Dapatkan posisi raket sekarang.
        Vector3 position = transform.position;

        // memberi batasan baik atas maupun bawah pada player
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukkan kembali posisinya ke transform.
        transform.position = position;
    }
    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai skor
    public int Score
    {
        get { return score; }
    }

    // Untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }
    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
