import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { TechSkill } from '../models/tech-skill';
import { TechSkillService } from '../dataServices/tech-skill.service';

import { SkillCategory } from '../models/skill-category';
import { SkillCategoryService } from '../dataServices/skill-category.service';

@Component({
  selector: 'app-tech-skill',
  templateUrl: './tech-skill.component.html',
  styleUrls: ['./tech-skill.component.css']
})
export class TechSkillComponent implements OnInit {
  techSkills: TechSkill[];
  skillCategories: SkillCategory[];
  columnsToDisplay = ['name','skillLevel'];

  getTechSkills(id: number)
  {
    this.techSkillService.getTechSkills(id).subscribe(skills => this.techSkills = skills.data);
  }

  getSkillCategories()
  {
    this.skillCategoryService.getSkillCategories().subscribe(skillCategories => this.skillCategories = skillCategories.data);
  }

  filterTechSkills(id: number): TechSkill[]
  {
    return this.techSkills.filter(skill => skill.skillCategoryId === id);
  }

  constructor(private activeRoute: ActivatedRoute, 
              private techSkillService: TechSkillService,
              private skillCategoryService: SkillCategoryService,
              private location: Location) { }

  ngOnInit() {
    let id: number;
    id = +this.activeRoute.snapshot.paramMap.get('id');
    this.getTechSkills(id);

    this.getSkillCategories();
  }

}