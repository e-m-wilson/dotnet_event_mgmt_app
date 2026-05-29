import { Box, Button, TextField, Typography } from '@mui/material'
import React, { useState } from 'react'

function ActivityCreateForm() {

    const [formData, setFormData] = useState({
        title: '',
        description: '',
        category: '',
        city: '',
        venue: '',
        latitude: '',
        longitude: ''
    });

  function handleSubmit(event: React.SubmitEvent){
    event.preventDefault();
    console.log(formData)
  }

  function handleChange(
    event: React.ChangeEvent<HTMLInputElement>
  ) {
    const {name, value} = event.target;

    setFormData((prev) => ({
        ...prev,
        [name]: value
    }));
  }


  return (
    <Box
    component='form'
    onSubmit={handleSubmit}
    >

        <Typography variant='h5'>Create Activity</Typography>

        <TextField
        label="Title"
        name="title"
        value={formData.title}
        onChange={handleChange}
        />

        <TextField
        label="Description"
        name="description"
        value={formData.description}
        onChange={handleChange}
        />

        <TextField
        label="Category"
        name="category"
        value={formData.category}
        onChange={handleChange}
        />

        <TextField
        label="City"
        name="city"
        value={formData.city}
        onChange={handleChange}
        />

        <TextField
        label="Venue"
        name="venue"
        value={formData.venue}
        onChange={handleChange}
        />

        <TextField
        label="Latitude"
        name="latitude"
        value={formData.latitude}
        onChange={handleChange}
        />

        <TextField
        label="Longitude"
        name="longitude"
        value={formData.longitude}
        onChange={handleChange}
        />

        <Button type="submit" variant='contained'>
            Submit
        </Button>

    </Box>
  )
}

export default ActivityCreateForm