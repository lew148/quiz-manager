import React, { useState } from 'react';
import { useForm } from "react-form";
import { post } from '../../Api';
import { TextField } from './InputTypes';
import { FaEdit, FaSave } from 'react-icons/fa';

const handleSubmit = async (apiRoute, values) => {
    await post(apiRoute, values);
    window.location.reload();
};

const EditForm = ({ objectId, apiEditRoute, placeholder }) => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            const fullApiRoute = `${apiEditRoute}/${objectId}`
            handleSubmit(fullApiRoute, values)
        },
    });

    const [editing, setEditing] = useState(false);

    const handleEditButtonClick = () => {
        setEditing(!editing)
    }

    return (
        <Form>
            <div className="d-flex">
                <button type="button" onClick={handleEditButtonClick} className="edit-button"><FaEdit /></button>
                {editing &&
                    <div className="d-flex">
                        <TextField
                            name="newDescription"
                            type="text"
                            additionalClassName="edit-input"
                            placeholder={placeholder}
                        />
                        <button type="submit" className="edit-button"><FaSave /></button>
                    </div>
                }
            </div>
        </Form>
    );
};

export default EditForm;