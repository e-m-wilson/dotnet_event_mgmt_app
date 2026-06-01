import { Button, Checkbox, FormControlLabel, Stack, TextField, Typography } from '@mui/material'
import React from 'react'
import type { Activity } from '../../types';
import { useActivities } from './useActivities';

type Props = {
  a?: Activity;
  mode: string;
  setEditModeOff: () => void;
}


function ActivityForm({a, mode, setEditModeOff}: Props) {

  const {createActivity, updateActivity, activity, isLoadingActivity} = useActivities(a?.id);

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
      setEditModeOff();
    } else {
      createActivity.mutateAsync(data as unknown as Activity);
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

        <Typography variant='h5'>Save Activity</Typography>

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
        {mode === 'edit' && <Button onClick={() => setEditModeOff()}>Cancel</Button>}

    </Stack>
  )
}

export default ActivityForm