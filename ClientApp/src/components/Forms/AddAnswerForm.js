import React from 'react';
import { useForm } from "react-form";
import { post } from '../../Api';
import { TextField, Select } from './InputTypes';

const convertFromIndexToOptionText = (num) => num + 1;

const constructQuestionOptions = (questions) => {
    var questionOptions = [];
    for (var i = 0; i < questions.length; i++) {
        if (questions[i].answers.length >= 5) continue; // if it has 5 questions (or more), don't appear in the list

        questionOptions.push({
            value: questions[i].id,
            text: convertFromIndexToOptionText(i)
        })
    }
    return questionOptions;
};

const handleSubmit = async (values) => {
    await post("answer/add", values);
    window.location.reload();
};

const AddAnswerForm = ({ questions }) => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            handleSubmit(values)
        },
    });

    const questionOptions = constructQuestionOptions(questions);

    return (
        <Form className="quiz-form">
            <h5>Add Answer</h5>
            <p className="text-muted">A question can only have 3 - 5 answers. The question will not appear in the list if it already has the maximum amount</p>
            <div className="d-flex">
                <div className="form-input-row" >
                    <TextField name="answer" type="text" placeholder="Answer"/>
                </div>
                <div className="form-input-row" >
                    <Select
                            field="questionId"
                            options={questionOptions}
                            description="Select question number to add an answer to"
                            defaultValue={questionOptions[0].value}
                        />
                </div>
                <button className="btn btn-primary btn-sm" type="submit">Add</button>
            </div>
        </Form>
    );
};

export default AddAnswerForm;