import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Student } from '../models/student.model';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit {
  public title = 'Alunos';
  public selectedStudent: Student | null = null;
  public studentForm!: FormGroup;
  public modalRef?: BsModalRef;
  public reqType: 'put' | 'post' = 'post';

  public students: Student[] = [];

  constructor(
    private fb: FormBuilder,
    private modalService: BsModalService,
    private studentService: StudentService
  ) {
    this.createForm(fb);
  }

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService
      .getAll()
      .subscribe({
        next: (data: Student[]) => {
          this.students = data;
        },
        error: (e: any) => {
          console.error(e);
        }
      });
  }

  saveStudent(student: Student) {
    (student.id == 0) ? this.reqType = 'post' : this.reqType = 'put';

    this.studentService
      [this.reqType](student)
      .subscribe({
        next: (result: Student) => {
          console.log(result);
          this.loadStudents();
        },
        error: (e: any) => {
          console.error(e);
        }
      });
  }

  createStudent() {
    this.selectedStudent = new Student();
    this.studentForm.patchValue(this.selectedStudent);
  }

  deleteStudent(id: Number) {
    this.studentService
    .delete(id)
    .subscribe({
      next: (data: String) => {
        console.log(data);
        this.loadStudents();
      },
      error: (e: any) => {
        console.error(e);
      }
    })
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  createForm(fb: FormBuilder) {
    this.studentForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      lastname: ['', Validators.required],
      phone: ['', Validators.required],
    });
  }

  selectStudent(student: Student) {
    this.selectedStudent = student;
    this.studentForm.patchValue(student);
  }

  unselectStudent() {
    this.selectedStudent = null;
  }

  submit() {
    this.saveStudent(this.studentForm.value);
  }
}
