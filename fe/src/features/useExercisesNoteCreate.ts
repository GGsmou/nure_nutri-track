import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { ExercisesNote } from "../types/ExercisesNote";

export const useExercisesNoteCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: ExercisesNote) => {
    if (filter.type === "edit") {
      return fetchAbstract("ExercisesNotes/" + filter.data.id, "PUT", data);
    }

    return fetchAbstract("ExercisesNotes/", "POST", data);
  });
};
