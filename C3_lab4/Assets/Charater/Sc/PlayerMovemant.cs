using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemant : MonoBehaviour
{
    // พารามิเตอร์การเคลื่อนที่ของตัวละคร
    public float speed = 10.0f;          // ความเร็วในการเคลื่อนที่
    public float jumpForce = 8.0f;       // แรงกระโดด
    public float gravity = 20.0f;         // แรงโน้มถ่วง
    public float rotationSpeed = 100.0f;  // ความเร็วในการหมุน

    // สถานะการอนิเมชัน
    public bool isGrounded = false;       // ตัวละครอยู่บนพื้นหรือไม่
    public bool isDef = false;             // สถานะป้องกัน
    public bool isDancing = false;         // สถานะเต้น
    public bool isWalking = false;         // สถานะเดิน

    private Animator animator;             // อ้างอิงถึง Animator
    private CharacterController characterController; // อ้างอิงถึง CharacterController
    private Vector3 inputVector = Vector3.zero;  // เวกเตอร์อินพุต
    private Vector3 targetDirection = Vector3.zero; // ทิศทางเป้าหมาย
    private Vector3 moveDirection = Vector3.zero; // ทิศทางการเคลื่อนที่
    private Vector3 velocity = Vector3.zero;       // ความเร็ว

    void Awake()
    {
        // เริ่มต้นคอมโพเนนต์
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isGrounded = characterController.isGrounded;  // <--- Corrected semicolon here
    }

    // Update is called once per frame
   void Update()
    {
        // รับค่าการเคลื่อนที่จากผู้เล่น
        float z = Input.GetAxis("Horizontal");
        float x = -(Input.GetAxis("Vertical"));

        // อัปเดตพารามิเตอร์อนิเมชัน
        animator.SetFloat("inputX", -(x));
        animator.SetFloat("InputZ", z);

        // ตรวจสอบว่าตัวละครกำลังเดินหรือไม่
        if (x != 0 || z != 0)
        {
            isWalking = true;
            animator.SetBool("isWalking", isWalking);
        }
        else
        {
            isWalking = false;
            animator.SetBool("isWalking", isWalking);
        }

        // ตรวจสอบว่าตัวละครอยู่บนพื้น
        isGrounded = characterController.isGrounded;
        if (isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

        }

        characterController.Move(moveDirection * Time.deltaTime);

        inputVector = new Vector3(x, 0, z);
    }
    void updateMovement()
    {
        Vector3 motion = inputVector;    
        motion = ((Mathf.Abs(motion.x) > 1) || (Mathf.Abs(motion.z) > 1)) ? motion.normalized : motion;

        
    }
}
