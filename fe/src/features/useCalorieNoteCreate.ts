import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { CalorieNote } from "../types/CalorieNote";

export const useCalorieNoteCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: CalorieNote) => {
    const type = filter.type === "edit" ? "PUT" : "POST";
    const params = type === "POST" ? `${data.userId}/${data.recepieId}/` : "";

    return fetchAbstract(`CalorieNotes/${params}`, type, {
      calories: data.calorie,
      id: data.id,
      createdAt: new Date(data.createdAt).toISOString(),
    });
  });
};
