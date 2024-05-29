import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useExerciseNoteDelete = () => {
  return useMutation((data: { id: number }) => {
    return fetchAbstract("ExercisesNotes/" + data.id, "DELETE");
  });
};
