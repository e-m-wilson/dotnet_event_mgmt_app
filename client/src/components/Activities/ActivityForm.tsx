import { Button, Checkbox, FormControlLabel, Stack, TextField, Typography } from '@mui/material'
import React from 'react'
import type { Activity } from '../../types';
import { useActivities } from './useActivities';
import { NavLink, useNavigate, useParams } from 'react-router';


function ActivityForm() {

  const navigate = useNavigate();
  const {id} = useParams();
  const {createActivity, updateActivity, activity, isLoadingActivity} = useActivities(id);

  async function handleSubmit(event: React.SubmitEvent){
    event.preventDefault();
    
    const formData = new FormData(event.target);
    const data: Record<string, unknown> = {}
    formData.forEach((value, key) => {
      data[key] = value;
    });

    // this forces data to populate with the 
    // value of the isCancelled checkbox
    data.isCancelled = formData.has('isCancelled');

    if(activity) {
      data.id = activity.id;
      await updateActivity.mutateAsync(data as unknown as Activity);
      navigate(`/activities/${activity.id}`)
    } else {
      createActivity.mutate(data as unknown as Activity, {
        onSuccess: (activity) => {
            navigate(`/activities/${activity.id}`)
        }
      });


    
    }

  }

  if(isLoadingActivity) return <Typography>Loading activity...</Typography>

  return (
    <Stack
    component='form'
    onSubmit={handleSubmit}
    direction={'column'}
    spacing={1}
    >

        <Typography variant='h5'>{activity ? 'Edit Activity' : 'Create Activity'}</Typography>

        <TextField
        label="Title"
        name="title"
        defaultValue={activity?.title}
        />

        <TextField
        label="Description"
        name="description"
        defaultValue={activity?.description}
        />

        <TextField
        label="Category"
        name="category"
        defaultValue={activity?.category}
        />

        <TextField
        label="City"
        name="city"
        defaultValue={activity?.city}
        />

        <TextField
        label="Venue"
        name="venue"
        defaultValue={activity?.venue}
        />

        <TextField
        label="Latitude"
        name="latitude"
        defaultValue={activity?.latitude}
        />

        <TextField
        label="Longitude"
        name="longitude"
        defaultValue={activity?.longitude}
        />

        <FormControlLabel 
        control={
          <Checkbox 
          name='isCancelled'
          defaultChecked={activity?.isCancelled}
          />
        }
        label="Cancelled?"
        />


        <Button type="submit" variant='contained'>
            Submit
        </Button>
        {activity && <Button component={NavLink} to={`/activities/${activity.id}`}>Cancel</Button>}

    </Stack>
  )
}

export default ActivityForm